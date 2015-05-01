﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViral
{
    public class LocationCollection : List<Location>
    {
        private static List<string> _rawLocationInfo;
        

        static LocationCollection() 
        {
            _rawLocationInfo = new List<string>();

            _rawLocationInfo.Add("West US|142,932,789|223,324|East US, South Canada, Mexico And Central America|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|South Canada, North Canada And Alaska, Mexico And Central America, Japan, North East China, South China");
            _rawLocationInfo.Add("East US|175,924,267|314,324|West US, South Canada, Mexico And Central America, North East US and East Canada|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|Mexico And Central America, South Canada");
            _rawLocationInfo.Add("South Canada|10,051,543|259,280|West US, East US, North East US and East Canada, North Canada and Alaska|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|West US, East US, Greenland ");
            _rawLocationInfo.Add("North Canada And Alaska|2,096,143|171,143|South Canada|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|South Alaska, West US, China, Japan, Australia");
            _rawLocationInfo.Add("Mexico And Central America|165,015,846|288,393|West US, North West South America|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|West US, East US, North West South America, East South America");
            _rawLocationInfo.Add("North East US And East Canada|22,154,879|355,272| South Canada, East US|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|East US, Greenland, West Europe");
            _rawLocationInfo.Add("North West South America|130,583,142|355,453| Mexico And Central America, East South America|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|West US, East US, Mexico and Central America");
            _rawLocationInfo.Add("East South America|203,429,773|441,497|North West South America, South South America|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|Mexico and Central America, South Africa, West Africa");
            _rawLocationInfo.Add("South South America|56,103,125|381,594|East South America, North West South America|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|North West South America, Mexico and Central America, South Africa, West Africa");
            _rawLocationInfo.Add("West Africa|245,087,391|632,443|North Africa, East Africa, South Africa|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|East South America, North West South America, Mexico and Central America");
            _rawLocationInfo.Add("East Africa|135,472,031|732,443|West Africa, North Africa, South Africa|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|India, South Middle East");
            _rawLocationInfo.Add("North Africa|8,935,659|614,344|West Africa, East Africa, North Middle East|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|South Europe");
            _rawLocationInfo.Add("South Africa|73,982,103|676,561|East Africa, West Africa|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|Australia, South South America, East South America");
            _rawLocationInfo.Add("West Europe|189,634,081|598,253|South Europe, East Europe|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|Greenland, North East US and East Canada, North Africa, West Africa");
            _rawLocationInfo.Add("North Europe|101,387,285|640,187|West Russia|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|Greenland");
            _rawLocationInfo.Add("East Europe|73,982,103|662,267|West Europe, South Europe, North Middle East, West Russia|North Russia, South Russia|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|");
            _rawLocationInfo.Add("South Europe|153,082,198|632,297|West Europe, East Europe|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|North Africa, North Middle East");
            _rawLocationInfo.Add("Greenland|56,483|508,143| |West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|North East US and East Canada, South Canada, West Europe, North Africa");
            _rawLocationInfo.Add("West Russia|81,092,096|742,204|North Europe, East Europe, North Middle East, North Russia, South Russia|North Russia, South Russia|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia | ");
            _rawLocationInfo.Add("North Russia|16,098,153|872,110|West Russia, South Russia, East Russia|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia| ");
            _rawLocationInfo.Add("South Russia|30,098,128|887,204|West Russia, East Russia, North Russia, North East China, North West China|North Russia, South Russia|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia| ");
            _rawLocationInfo.Add("East Russia|12,124,129|1016,143|North Russia, South Russia|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|North East China, Japan, West US, South Canada, North Canada And Alaska");
            _rawLocationInfo.Add("South Middle East|126,008123|754,384|North Middle East, North Africa|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|India, East Africa");
            _rawLocationInfo.Add("North East China|210,746,323|970,297|North West China, South China|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|New Zealand, Australia, Japan, West Indonesia, East Indonesia, West US, South Canada, North Canada And Alaska");
            _rawLocationInfo.Add("South China|268,903,132|970,353|North West China, North East China, India|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|India, New Zealand, Australia, Japan, West Indonesia, East Indonesia, West US");
            _rawLocationInfo.Add("North West China|430,891,197|898,297| North East China, South China, India, South Russia|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia| ");
            _rawLocationInfo.Add("India|1,276,562,789|861,372|North West China, South China, North Middle East|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia| South China, West Indonesia, East Indonesia, South Middle East, Australia, New Zealand");
            _rawLocationInfo.Add("North Middle East|132,681,782|732,324|South Middle East, India|West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia| ");
            _rawLocationInfo.Add("Japan|134,098,178|1054,297| |West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|China, East Russia, West US, Australia, East Indonesia, South Canada, North Canada And Alaska");
            _rawLocationInfo.Add("West Indonesia|250,678,124|985,453| |West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|East Indonesia, China, Japan, Australia");
            _rawLocationInfo.Add("East Indonesia|260,301,019|1080,476| |West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|West Indonesia, China, India, Japan, Australia");
            _rawLocationInfo.Add("Australia|23,073,471|1080,594| |West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|New Zealand, Japan, South China, India");
            _rawLocationInfo.Add("New Zealand|5,091,312|1163,654| |West US, East US, South Canada, North Canada, Mexico And Central America, North East US And East Canada, North West South America, East South America, South South America, West Africa, North Africa, South Africa, East Africa, North Europe, East Europe, South Europe, West Europe, Greenland, West Russia, East Russia, North Russia, South Russia, South Middle East, North West China, North East China, South China, India, North Middle East, Australia, New Zealand, Japan, West Indonesia, East Indonesia|Australia, South China, West Indonesia, East Indonesia, Japan, India");
        }

        public void Load()
        {
            foreach (string rawInfo in _rawLocationInfo)
            {
                Location newLocation = new Location(rawInfo);
                this.Add(newLocation);
            }
        }
    }
}

