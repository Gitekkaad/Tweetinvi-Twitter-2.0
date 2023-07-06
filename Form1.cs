

//  (C) 2023 Farmer Basics

using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweetinvi;
using Tweetinvi.Models;

namespace Twittap
{
    public partial class Form1 : Form
    {
        public ITweet[] timeline;
        //public TwitterClient client;
        public ITweet[] Tweets;
      
        public Form1()
        {
            InitializeComponent();
            

        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new TwitterClient(


                AccessToken
                AccessTokenSecret
                ConsumerKey
                ConsumerSecret
                   
                );

                var user = client.Users.GetAuthenticatedUserAsync().Result;

                MessageBox.Show($"You are now authenticated as {user}!");

                //*****************************************************************

                if (user != null)
                {
                    StringBuilder sb = new StringBuilder();
                    DisplayUserProperties(user, sb);

                    textBox1.Text = sb.ToString();
                }

                void DisplayUserProperties(object obj, StringBuilder sb, string prefix = "")
                
                {
                    var properties = obj.GetType().GetProperties();

                    foreach (var property in properties)
                    {
                        var propertyName = property.Name;
                        var propertyValue = property.GetValue(obj);

                        if (propertyValue != null && property.PropertyType.Assembly == obj.GetType().Assembly)
                        {
                            sb.AppendLine($"{prefix}{propertyName}:");
                            DisplayUserProperties(propertyValue, sb, prefix + "    ");
                        }
                        else
                        {
                            sb.AppendLine($"{prefix}{propertyName}: {propertyValue}");
                        }
                    }
                }



                timeline = client.Timelines.GetUserTimelineAsync(user).Result;

                

                DisplayTweetsInTextBox();

            }
            catch (Exception ex)
            {
                
                
                //textBox1.Text = ex.ToString();
                textBox1.Update();

            }
        }

        public void DisplayTweetsInTextBox()
        {
            if (timeline != null)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var tweet in timeline)
                {
                    sb.AppendLine(tweet.Text);
                }

                textBox1.Text = sb.ToString();
            }
        }

      
    }
}




