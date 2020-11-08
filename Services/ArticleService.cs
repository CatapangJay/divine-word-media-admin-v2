using DivineWordAdmin.Enums;
using DivineWordAdmin.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DivineWordAdmin.Services
{
    public class ArticleService
    {
        private FirestoreDb _firestoreDb;
        private readonly string collectionName = Collections.articles.ToString();
        public ArticleService()
        {
            _firestoreDb = InitializeFirestore();
        }

        public async Task<IEnumerable<Article>> GetAllArticles()
        {
            Query query = _firestoreDb.Collection(collectionName);
            QuerySnapshot articlesSnapshots = await query.GetSnapshotAsync();

            IEnumerable<Article> articles = articlesSnapshots.Where(snap => snap.Exists).Select(snap => { return snap.ConvertTo<Article>(); });

            return articles;
        }
        public async Task<IEnumerable<Article>> GetAllArticleById()
        {
            Query query = _firestoreDb.Collection(collectionName);
            QuerySnapshot articlesSnapshots = await query.GetSnapshotAsync();

            IEnumerable<Article> articles = articlesSnapshots.Where(snap => snap.Exists).Select(snap => { return snap.ConvertTo<Article>(); });

            return articles;
        }
        private FirestoreDb InitializeFirestore()
        {
            string fbConfigPath = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
            string config = string.Empty;

            using (StreamReader reader = new StreamReader(fbConfigPath))
                config = reader.ReadToEnd();

            JObject configObj = JObject.Parse(config);

            string fbProjectId = configObj.SelectToken("project_id").ToString();

            return FirestoreDb.Create(fbProjectId);
        }
    }
}
