﻿using Microsoft.AspNetCore.Http;

namespace Core.DTO.Collection
{
    public class CollectionInfoUpdateDTO
    {
        public int collectionId { get; set; }
        public string collectionName { get; set; }
        public string collectionCover { get; set; }
    }
}
