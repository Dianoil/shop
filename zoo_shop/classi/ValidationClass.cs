﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo_shop.classi
{
    class ValidationClass
    {
        public static bool ValidateFIO(string name, string fname)
        {
            int s = 0;
            while (s < name.Length && s < fname.Length)
            {
                if ((name[s] >= 'А' && name[s] <= 'Я' ||
                    name[s] >= 'а' && name[s] <= 'я') ||
                    ((name[s] == '-' || name[s] == ' ') &&
                    (name[s] >= 'А' && name[s] <= 'Я' ||
                    name[s] >= 'а' && name[s] <= 'я')))
                {
                    if ((fname[s] >= 'А' && fname[s] <= 'Я' ||
                    fname[s] >= 'а' && fname[s] <= 'я') ||
                    ((fname[s] == '-' || fname[s] == ' ') &&
                    (fname[s] >= 'А' && fname[s] <= 'Я' ||
                    fname[s] >= 'а' && fname[s] <= 'я')))
                    {
                        s++;
                    }
                    else return false;
                }
                else return false;

            }
            return true;
        }
        public static bool ValidateBirth(DateTime birth)
        {
            try
            {
                DateTime b = birth;
                while (b <= DateTime.Now)
                {
                return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}