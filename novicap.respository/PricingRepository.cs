using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using novicap.app.entities;
using novicap.app.repositories;
using novicap.app.Exceptions;

namespace novicap.respository
{
    public class PricingRepository : IPricingRepository
    {
        private string filePath;
        public PricingRepository(string connection)
        {
            this.filePath = connection;
        }

        public Hashtable GetPricingData()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    Hashtable pricingData = new Hashtable();
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string json = reader.ReadToEnd();
                        List<Product> items = JsonConvert.DeserializeObject<List<Product>>(json);
                        foreach (var item in items)
                        {
                            if (pricingData.ContainsKey(item))
                            {
                                throw new DuplicateKeyException();
                            }
                            pricingData.Add(item.Code, item);
                        }
                    }
                    return pricingData;
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
