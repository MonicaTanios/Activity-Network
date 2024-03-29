﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace IS_Project
{
    class Node
    {
        public string name;
        public int ES, EF, LS, LF, durationTime, V1, V2, level, vis;
        List<string> Dep;
        List<int> Child;
        public List<int> rChild;
        public bool isCritical;
        public int btnIndex;
        public bool isFree;
        public Node()
        {
            isCritical = false;
            isFree = true;
            name = "2";
            durationTime = 0;
            ES = 0;
            EF = 0;
            LS = 0;
            LF = 0;
            level = 0;
            vis = 0;
            Dep = new List<string>();
            Child = new List<int>();
            rChild = new List<int>();
        }

        public int calculateLS()
        {
            LS = LF - durationTime;
            return LS;
        }
        public void takeInput()
        {
            Console.WriteLine("Enter task name: ");
            name = Console.ReadLine();

            Console.WriteLine("Enter task task duration: ");
            durationTime = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter task number of dependencies: ");
            string depen = Console.ReadLine();
            string OneDep = "";
            for (int i = 0; i < depen.Length; i++)
            {
                if (depen[i] == ' ')
                {
                    if (OneDep.Length >= 1)
                    {
                        Dep.Add(OneDep);
                    }
                    OneDep = "";
                }
                else
                    OneDep += depen[i];
            }
            if (OneDep.Length >= 1)
            {
                Dep.Add(OneDep);
            }
            return;
        }
        
        public void strTOint(IDictionary<string, int> rename)
        {
            foreach (string i in Dep)
            {
                Child.Add(rename[i]);
            }
        }
        public void print()
        {
            Console.WriteLine(name);
            Console.WriteLine("The Early Start is : " + ES + " and The Early Finish is : " + EF);
            Console.WriteLine("The Last Start is : " + LS + " and The Last Finish is : " + LF);
            Console.WriteLine((isCritical) ? "Yup" : "NO");

            Console.WriteLine("The Node lvl :" + level);
            Console.WriteLine();
        }

        public List<int> child()
        {
            return Child;
        }

    }
}
