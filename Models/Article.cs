using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivineWordAdmin.Models
{
    [FirestoreData]
    public class Article
    {
        [FirestoreProperty(Name = "id")]
        public string Id { get; set; }

        [FirestoreProperty(Name = "articleurl")]
        public string ArticleUrl { get; set; }

        [FirestoreProperty(Name = "author")]
        public string Author { get; set; }

        [FirestoreProperty(Name = "body")]
        public string Body { get; set; }

        [FirestoreProperty(Name = "header")]
        public string Header { get; set; }

        [FirestoreProperty(Name = "imageurl")]
        public string ImageUrl { get; set; }

        [FirestoreProperty(Name = "publishdate")]
        public DateTime PublishDate { get; set; }
    }
}
