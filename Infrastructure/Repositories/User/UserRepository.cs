﻿using Core.DTO.User;
using Core.Interfaces.User;
using Core.Utilities;
using Dapper;
using Firebase.Auth;
using Infrastructure.Data;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Infrastructure.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext context;
        FirebaseAuthProvider auth;

        public UserRepository(DapperContext context)
        {
            this.context = context;
            auth = new FirebaseAuthProvider(
                            new FirebaseConfig(context.FireBaseKey()));
        }

        public async Task<UserInfoDTO> SignIn(UserSignInDTO userMod)
        {
            ////create the user
            await auth.CreateUserWithEmailAndPasswordAsync(userMod.userEmail, userMod.pwd);
            //log in the new user
            var fbAuthLink = await auth
                            .SignInWithEmailAndPasswordAsync(userMod.userEmail, userMod.pwd);
            string token = fbAuthLink.FirebaseToken;
            //saving the token in a session variable
            if (token != null)
            {
                var path = "userInfo/" + fbAuthLink.User.LocalId;
                string imageUrl = await ImageUtility.uploadImage(context.FireBaseKey(), context.FireBaseBucket(), context.FireBaseUser(), context.FireBasePassword(), path, userMod.userPhoto);
                
                var query = "sp_userInfo_Insert";

                var parameters = new DynamicParameters();
                parameters.Add("@userId", fbAuthLink.User.LocalId, DbType.String);
                parameters.Add("@userName", userMod.userName, DbType.String);
                parameters.Add("@userLastName", userMod.userLastName, DbType.String);
                parameters.Add("@userEmail", userMod.userEmail, DbType.String);
                parameters.Add("@userPhoto", imageUrl, DbType.String);
                parameters.Add("@fk_loginTypeId", userMod.fk_loginTypeId, DbType.Int32);

                using var connection = context.SQLConnection();
                UserInfoDTO UserInfo = await connection.QueryFirstOrDefaultAsync<UserInfoDTO>(query, parameters, commandType:CommandType.StoredProcedure);
                return UserInfo;
            }
            
            return null;
        }

        public async Task<UserInfoDTO> LoginIn(UserLoginDTO loginDTO)
        {

            //log in the new user
            var fbAuthLink = await auth
                            .SignInWithEmailAndPasswordAsync(loginDTO.Email, loginDTO.Password);
            string token = fbAuthLink.FirebaseToken;
            //saving the token in a session variable
            if (token != null)
            {
                var query = "sp_userInfo_get";

                var parameters = new DynamicParameters();
                parameters.Add("@userId", fbAuthLink.User.LocalId, DbType.String);

                using var connection = context.SQLConnection();
                UserInfoDTO UserInfo = await connection.QueryFirstOrDefaultAsync<UserInfoDTO>(query, parameters, commandType: CommandType.StoredProcedure);
                return UserInfo;
            }


            return null;
        }

        public async Task<UserInfoDTO> UserUpdateInfo(UserInfoDTO user)
        {
            var query = "sp_userInfo_Update";

            var parameters = new DynamicParameters();
            parameters.Add("@userId", user.userId, DbType.String);
            parameters.Add("@userName", user.userName, DbType.String);
            parameters.Add("@userLastName", user.userLastName, DbType.String);

            using var connection = context.SQLConnection();
            UserInfoDTO UserInfo = await connection.QueryFirstOrDefaultAsync<UserInfoDTO>(query, parameters, commandType: CommandType.StoredProcedure);
            return UserInfo;
        }

        public async Task<UserInfoDTO> UserUpdatePhotoInfo(UserUpdatePhotoDTO userUpdate)
        {

            var path = "userInfo/" + userUpdate.userId;          
            string imageUrl = await ImageUtility.uploadImage(context.FireBaseKey(), context.FireBaseBucket(), context.FireBaseUser(), context.FireBasePassword(), path, userUpdate.userPhoto);
            
            var query = "sp_userInfo_Photo_Update";

            var parameters = new DynamicParameters();
            parameters.Add("@userId", userUpdate.userId, DbType.String);
            parameters.Add("@userPhoto", imageUrl, DbType.String);

            using var connection = context.SQLConnection();
            UserInfoDTO UserInfo = await connection.QueryFirstOrDefaultAsync<UserInfoDTO>(query, parameters, commandType: CommandType.StoredProcedure);
            return UserInfo;
        }

        public Task UserUpdatePwdInfo(UserUpdatePasswordDTO userUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
