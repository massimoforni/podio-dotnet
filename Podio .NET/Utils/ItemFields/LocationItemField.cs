﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using PodioAPI.Models;

namespace PodioAPI.Utils.ItemFields
{
    public class LocationItemField : ItemField
    {
        public IEnumerable<string> Locations
        {
            get
            {
                if (this.Values != null && this.Values.Any())
                    return new List<string>(this.Values.Select(s => (string) s["value"]));
                else
                    return new List<String>();
            }

            set
            {
                ensureValuesInitialized();
                foreach (var location in value)
                {
                    var jobject = new JObject();
                    jobject["value"] = location;
                    this.Values.Add(jobject);
                }
            }
        }

        public string Location
        {
            set
            {
                ensureValuesInitialized();

                var jobject = new JObject();
                jobject["value"] = value;
                this.Values.Add(jobject);
            }
        }

        public double? Latitude
        {
            get
            {
                if (this.Values.Any())
                {
                    return (double?)this.Values.First["lat"];
                }

                return null;
            }
        }

        public double? Longitude
        {
            get
            {
                if (this.Values.Any())
                {
                    return (double?)this.Values.First["lng"];
                }

                return null;
            }
        }

        public string Country
        {
            get
            {
                if (this.Values.Any())
                {
                    return (string)this.Values.First["country"];
                }

                return null;
            }
        }

        public string State
        {
            get
            {
                if (this.Values.Any())
                {
                    return (string)this.Values.First["state"];
                }

                return null;
            }
        }     
    }
}