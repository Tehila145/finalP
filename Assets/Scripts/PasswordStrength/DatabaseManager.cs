// using MongoDB.Bson;
// using MongoDB.Driver;
// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class DatabaseManager : MonoBehaviour
// {
//     private MongoClient client;
//     private IMongoDatabase database;
//     public HashSet<string> commonPasswords = new HashSet<string>();
//     public bool IsReady { get; private set; } // Indicates if the passwords have been fetched
//
//     void Awake()
//     {
//         InitializeDatabase();
//     }
//
//     void InitializeDatabase()
//     {
//         Debug.Log("Initializing Database Manager...");
//         try
//         {
//             string connectionString = "mongodb+srv://tehilaschool14:t!123456@passwords.ya9ypni.mongodb.net/?retryWrites=true&w=majority&appName=passwords";
//             client = new MongoClient(connectionString);
//             database = client.GetDatabase("passwords");
//             StartCoroutine(FetchCommonPasswords());
//         }
//         catch (Exception ex)
//         {
//             Debug.LogError("Failed to connect to MongoDB: " + ex.Message);
//         }
//     }
//
//     IEnumerator FetchCommonPasswords()
//     {
//         var collection = database.GetCollection<BsonDocument>("commonPasswords");
//         var filter = new BsonDocument();
//         var findOptions = new FindOptions<BsonDocument> { BatchSize = 100 };
//         
//         var task = collection.FindAsync(filter, findOptions);
//         yield return new WaitUntil(() => task.IsCompleted);
//
//         if (task.IsFaulted)
//         {
//             Debug.LogError("Error fetching data: " + task.Exception.ToString());
//         }
//         else
//         {
//             using (var cursor = task.Result)
//             {
//                 while (cursor.MoveNext())
//                 {
//                     var batch = cursor.Current;
//                     foreach (var doc in batch)
//                     {
//                         commonPasswords.Add(doc["password"].AsString);
//                     }
//                 }
//             }
//             IsReady = true; // Set the ready flag to true once data is loaded
//             Debug.Log("Common passwords fetched and stored.");
//         }
//     }
//
//     public bool CheckCommonPassword(string password)
//     {
//         return commonPasswords.Contains(password);
//     }
// }
