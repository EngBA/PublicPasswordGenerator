/*
    File:       Form1.cs
    Version:    1.0
    Date:       8-Jan-2021
    Name:       Bilal AL-ISSA
    Supervisor: Carlos Osoria
    Gen. Info:  A part of project of C# .NET course associated with ComIT.org, Winter 2021
    Prog. Det.: 
                - Current version features:
                    - code built by applying OOP which is thru classes environment
                    - Generating random string characters as a length of 4-1024 char length, 8 chars as default choice
                        - string base chars: "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()/?';[{]}|~-_=+"
                    - User is able to copy and/or manipulate the generated string (password)
                        - copied string to be saved into Clipboard of the operating system
                        - a confirmation note appears whene:
                            - password had been generated
                            - password field has been copied
                - Next version features:
                    - let the user chooses one of following lists to generate a desired password/string:
                        - "abcdefghijklmnopqrstuvwxyz"
                        - "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                        - "0123456789"
                        - "!@#$%^&*()/?';[{]}|~-_=+"
                        - "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()/?';[{]}|~-_=+"
                        - let the user add more characters, like other languages
                    - a confirmation copy note disappears after 3 seconds
                    - a link a new form to show info about:
                        - the application
                        - a way to contact
                - Next after version features:
                    - a control panel to let the user able to change some settings:
                        - default length of generated password
                        - add more chars to base char lists
                        - confirmation copying note
                            - hide/show
                            - show time
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsPasswordGeneratorV1
{
     public partial class Frm_MainWindow : Form
    {

        // declaring main class variables
        static string myPwLen, txtPw, copyProcStat, defualtStat = "B. A. C#,NET ComIT.org Feb 8 2021 ©";

        class pwGenerator
        {
            // Declaring class variables
            public static pwGenerator generatedPw = new pwGenerator();
            public static pwGenerator progStatus = new pwGenerator();

            public pwGenerator() {}

            public string getPwd()
            {
                string num1 = Frm_MainWindow.myPwLen;
                int intnum = Convert.ToInt32(num1);

                var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()/?';[{]}|~-_=+";
                var stringChars = new char[intnum]; // Defining char array "char[x]" and assign it to a variable "stringChars", its length comes from ComboBox which changes by user
                var random = new Random(); // Invoke the program to generate random chars based on defined string variable "chars"
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)]; // Passing thru the char array items to pick up random chars and append them 
                }

                string generatedPw = new String(stringChars); // Store the created string (generated password) into txtBox

                return generatedPw;
            }

            public string getStatus()
            {
                string progStatus = "Generated password length: " + Frm_MainWindow.myPwLen.ToString();

                return progStatus;
            }

            //public string delayFun()
            //{
            //    System.Threading.Thread.Sleep(3000);
            //    string progStatus = defualtStat;

            //    return progStatus;
            //}
        }

        class copyPw
        {
            // declaring class variavles
            public static copyPw copyStat = new copyPw();
            public static copyPw copy = new copyPw();

            public copyPw() { }

            public void copyPwd()
            {
                bool emptyVarFlag = false;
                string copy = txtPw;

                if (copy != "")
                {
                    emptyVarFlag = true;
                }
                if (emptyVarFlag == false)
                {
                    copyProcStat = copyPw.copyStat.getStatus2();
                }
                else
                {
                    Clipboard.SetText(copy); //Copy textBox to Clipboard
                    copyProcStat = copyPw.copyStat.getStatus1();
                }

            }


            public string getStatus1()
            {
                string copyStat = "Password copied!";
                return copyStat;
            }

            public string getStatus2()
            {
                string copyStat = "Clipboard is empty!";
                return copyStat;
            }
        }

        public Frm_MainWindow()
        {
            InitializeComponent();
            Clipboard.Clear();    //Clear if any old value is there in Clipboard
        }

        private void btn_GeneratePassword_Click(object sender, EventArgs e)
        {
            decimal num = numcUpDw_PWLength.Value;
            Frm_MainWindow.myPwLen = num.ToString();

            lbl_Status.Text = pwGenerator.progStatus.getStatus();
            txtBox_Password.Text = pwGenerator.generatedPw.getPwd();

            //pwGenerator.generatedPw.delayFun();
        }

        public void numcUpDw_PWLength_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPw = txtBox_Password.Text.ToString();

            copyPw.copy.copyPwd();
            lbl_Status.Text = copyProcStat.ToString(); // copyPw.copyStat.getStatus1();

            //pwGenerator.generatedPw.delayFun();
        }


        private void lbl_Status_Click(object sender, EventArgs e)
        {
        }

    }


}
