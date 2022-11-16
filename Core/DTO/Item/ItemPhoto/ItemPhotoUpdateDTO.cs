using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Item.ItemPhoto
{
    public class ItemPhotoUpdateDTO
    {
        public int itemPhotoId { get; set; }
        public string itemPhoto { get; set; }
    }
}
