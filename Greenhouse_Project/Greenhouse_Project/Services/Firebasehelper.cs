using System;
using System.Collections.Generic;
using Greenhouse_Project.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Text;
using Greenhouse_Project.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Greenhouse_Project.Services
{
    class Firebasehelper
    {
        FirebaseClient firebase = new FirebaseClient("https://fireiot-c2911-default-rtdb.firebaseio.com/");
        public async Task<List<DHT11Sensor>> GetAllData()
        {
            return (await firebase.Child("Temprature").OnceAsync<DHT11Sensor>()).Select(item => new DHT11Sensor
            {
                temprature = item.Object.temprature,
                humidity = item.Object.humidity
            }).ToList();

 
        }
        //public async Task<DHT11Sensor> Gettemp(int temprature)
        //{
        //    var tempdata = await GetAllData();
        //    await firebase.Child("Temprature").OnceAsync<DHT11Sensor>();
        //    return tempdata.Where(a => a.temprature == temprature).FirstOrDefault();

        //}
    }
}
