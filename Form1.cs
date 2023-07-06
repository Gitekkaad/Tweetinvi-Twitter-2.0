﻿



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
                    "PmJowiyoqre67P8WM7soldduG",
                    "QURzQcPfg42TrqXHrWlNtRqw3nvrgDPOmLNmHZr5Oq4WTu8Y1w",
                    "151238035-h2KTVLc7OLCSNxqFifY90oLZl6ir7FckcdVZRoAL",
                    "l68Z5fNoUN2nGpMnvP7Iu7XkmY0jMjqm21A7cMJHXHnH2"
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



                MessageBox.Show($"You are now authenticated as {user}!");














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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}




/*
 * 
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

        private ITweet[] timeline;


        public Form1()
        {
            InitializeComponent();



        }

        private void button1_Click(object sender, EventArgs e)
        {

            // var client = new TwitterClient("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");

            try

            {

                var client = new TwitterClient(

                    "PmJowiyoqre67P8WM7soldduG",
                    "QURzQcPfg42TrqXHrWlNtRqw3nvrgDPOmLNmHZr5Oq4WTu8Y1w",
                    "151238035-h2KTVLc7OLCSNxqFifY90oLZl6ir7FckcdVZRoAL",
                    "l68Z5fNoUN2nGpMnvP7Iu7XkmY0jMjqm21A7cMJHXHnH2"

                    );


                var user = client.Users.GetAuthenticatedUserAsync().Result;

                MessageBox.Show($"You are now authenticated as {user}!");

                //_ = GetHomeTimelineAsync();

                // Task.Run(async () => await GetHomeTimelineAsync()).Wait();

                timeline = await GetHomeTimelineAsync();

                DisplayTweetsInTextBox();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Shape processing failed.");

                // throw;
            }


            async Task<ITweet[]> GetHomeTimelineAsync()

            {
                var timeline = await TimelineAsync.GetHomeTimeline();
                return timeline.ToArray();
            }



            void DisplayTweetsInTextBox()

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
}


Ausgeschniten



        public async Task GetHomeTimelineAsync()
        {
            // var authenticatedUser = client.Users.GetAuthenticatedUserAsync().Result;

            // timeline = await client.Timelines.GetHomeTimelineAsync((Tweetinvi.Parameters.IGetHomeTimelineParameters)authenticatedUser);

            try
            {
                // timeline = await client.Timelines.GetUserTimelineAsync("tweetinviapi");

                //timeline = await client.Timelines.GetUserTimelineAsync(user).Result;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Shape processing failed.");
            }


            DisplayTweetsInTextBox();
        }


*/