using BusinessSystemMVC_Admin_page_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessSystemMVC_Admin_page_.Metadatas
{
    [MetadataType(typeof(BulletinBoardMetadata))]
    public partial class BulletinBoard
    {
        public Nullable<System.DateTime> PostTime { get; set; }
    }
}