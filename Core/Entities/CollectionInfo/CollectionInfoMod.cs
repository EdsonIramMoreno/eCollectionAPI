﻿using System.Data.SqlTypes;

namespace Core.Entities.CollectionInfo
{
    public class CollectionInfoMod
    {
        public int collectionId { get; set; }
        public string collectionName { get; set; }
        public string collectionCover { get; set; }
        public float totalPrice { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastUpdateDate { get; set; }
        public string fk_userId { get; set; }
    }
}
