﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetStudio
{
    public class PlayerSettings
    {
        public string companyName;
        public string productName;

        public PlayerSettings(AssetPreloadData preloadData)
        {
            var sourceFile = preloadData.sourceFile;
            var reader = preloadData.InitReader();


            if ((sourceFile.version[0] == 5 && sourceFile.version[1] >= 4) || sourceFile.version[0] > 5)//5.4.0 nad up
            {
                //productGUID
                reader.ReadInt32();
                reader.ReadInt32();
                reader.ReadInt32();
                reader.ReadInt32();
            }
            if (sourceFile.version[0] >= 3)
            {
                if (sourceFile.version[0] == 3 && sourceFile.version[1] < 2)
                {
                    string AndroidLicensePublicKey = reader.ReadAlignedString();
                }
                else
                {
                    bool AndroidProfiler = reader.ReadBoolean(); reader.AlignStream(4);
                }

                int defaultScreenOrientation = reader.ReadInt32();
                int targetDevice = reader.ReadInt32();

                if (sourceFile.version[0] < 5 || (sourceFile.version[0] == 5 && sourceFile.version[1] < 1))
                {
                    int targetGlesGraphics = reader.ReadInt32();
                }

                if ((sourceFile.version[0] == 5 && sourceFile.version[1] < 1) || (sourceFile.version[0] == 4 && sourceFile.version[1] == 6 && sourceFile.version[2] >= 3))
                {
                    int targetIOSGraphics = reader.ReadInt32();
                }

                if (sourceFile.version[0] >= 5 || sourceFile.version[0] == 5 && (sourceFile.version[1] > 2 || (sourceFile.version[1] == 2 && sourceFile.version[2] >= 1)))
                {
                    bool useOnDemandResources = reader.ReadBoolean(); reader.AlignStream(4);
                }

                if (sourceFile.version[0] < 5 || (sourceFile.version[0] == 5 && sourceFile.version[1] < 3))
                {
                    int targetResolution = reader.ReadInt32();
                }

                if (sourceFile.version[0] == 3 && sourceFile.version[1] <= 1)
                {
                    bool OverrideIPodMusic = reader.ReadBoolean(); reader.AlignStream(4);
                }
                else if (sourceFile.version[0] == 3 && sourceFile.version[1] <= 4)
                {

                }
                else//3.5.0 and up
                {
                    int accelerometerFrequency = reader.ReadInt32();
                }
            }
            //fail in version 5 beta
            companyName = reader.ReadAlignedString();
            productName = reader.ReadAlignedString();
        }
    }
}
