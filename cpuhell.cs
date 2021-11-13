using System;
using System.Collections.Generic;

namespace TT
{
    class Program
    {

        static void Main(string[] args)
        {
            List<InputValue> inputvalue = new List<InputValue>();


            while (true)
            {

                string InputIntruction = Console.ReadLine(); //รับค่ามาใส่ตัวแปรInputIntruction
                if (InputIntruction == "?")
                {
                    calculate(inputvalue);
                    break; //หยุดloop
                }
                else
                {
                    inputvalue.Add(InputIntructionAndDaTa(InputIntruction)); //loopเรื่อยๆ , ส่งค่าที่ได้รับมาไปที่ฟังก์ชั่น InputIntructionAndDaTa
                }
            }

        }
        static InputValue InputIntructionAndDaTa(string value)
        {


            string[] words = value.Split(' '); //ตัดค่าที่เรากำหนดในวงเล็บออกและแบ่งค่าตามตัวในวงเล็บ
            string Intruction = words[0]; //ค่าแรกที่splitออกมาเอามาใส่เป็นค่าของintruction
            string Data = words[1];//ค่าสองที่splitออกมาเอามาใส่เป็นค่าของData
            InputValue inputValue = new InputValue(); //ดึงclass มาใช้
            inputValue.Intruction = Intruction; //เก็บค่า
            inputValue.Data = Data; //เก็บค่า
            return inputValue; //คืนค่ามันกลับไปจ้า

        }

        static void calculate(List<InputValue> inputvalue,int count = 0) 
        {
            count++;
            List<InputValue> waitingdata = new List<InputValue>();
            CPU[] cpu = new CPU[4]; //ที่เก็บค่า 
            for (int a = 0; a < cpu.Length; a++)
            {
                cpu[a] = new CPU();
            }
            
            for (int i = 0; i < inputvalue.Count; i++)
            {
                string ins = inputvalue[i].Intruction;
                for (int j = 0; j < cpu.Length; j++)
                {
                    
                    if (cpu[j].CpuIntruction == null || cpu[j].CpuIntruction == ins)
                    {
                        cpu[j].CpuIntruction = ins;

                        for (int b = 0; b < cpu[j].CpuData.Length; b++)
                        {
                            if (cpu[j].CpuData[b] == null || cpu[j].CpuData[b] == inputvalue[i].Data)
                            {
                                cpu[j].CpuData[b] = inputvalue[i].Data;
                                break;
                            }
                            else if(b == cpu[j].CpuData.Length-1)
                            {
                            waitingdata.Add(inputvalue[i]);
                            break;
                            }


                            
                        }
                      break;
                    }
                    else if (j == cpu.Length-1) 
                    {
                        waitingdata.Add(inputvalue[i]);
                        
                    }
                   
                }
            }
            if (waitingdata.Count > 0)
            {
                /*for (int i = 0; i < waitingdata.Count; i++)
                {
                    Console.WriteLine(waitingdata[i].Intruction+" "+ waitingdata[i].Data);
                เช็คตัวเกินสำหรับรอบต่อไป
                }
                Console.WriteLine(waitingdata.Count);*/
                calculate(waitingdata, count);
                
            }
            else 
            {
                Console.WriteLine("CPU cycles needed: "+count);
            }
        }
    }

    class InputValue 
    {
       public string Intruction,Data; //ภาชนะ
    }
    class CPU
    {
        public string CpuIntruction;
        public string[] CpuData = new string[3];
    }

    /*for (int i = 0; i<inputvalue.Count; i++) 
    {
        Console.WriteLine(inputvalue[i].Intruction+" "+ inputvalue[i].Data); เอาไว้ตรวจค่าที่เราเก็บไว้ในlistแปะเอาไว้อ่านเฉยๆ
    }*/  
}
