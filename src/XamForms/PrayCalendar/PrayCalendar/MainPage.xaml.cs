﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace PrayCalendar
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private static readonly string _rawPrayTimes =
            "{    \"jan\": [        [            \"1 - 3\",            \"5:00\",            \"6:22\",            \"12:15\",            \"3:36\",            \"4:28\",            \"6:06\",            \"7:21\"        ],        [            \"4 - 6\",            \"5:02\",            \"6:24\",            \"12:17\",            \"3:38\",            \"4:31\",            \"6:08\",            \"7:23\"        ],        [            \"7 - 8\",            \"5:03\",            \"6:25\",            \"12:18\",            \"3:39\",            \"4:32\",            \"6:09\",            \"7:24\"        ],        [            \"9 - 10\",            \"5:04\",            \"6:25\",            \"12:19\",            \"3:40\",            \"4:33\",            \"6:10\",            \"7:25\"        ],        [            \"11 - 12\",            \"5:05\",            \"6:26\",            \"12:20\",            \"3:41\",            \"4:34\",            \"6:11\",            \"7:26\"        ],        [            \"13-15\",            \"5:06\",            \"6:27\",            \"12:20\",            \"3:42\",            \"4:34\",            \"6:12\",            \"7:27\"        ],        [            \"16 - 17\",            \"5:07\",            \"6:28\",            \"12:22\",            \"3:44\",            \"4:36\",            \"6:14\",            \"7:28\"        ],        [            \"18 - 20\",            \"5:08\",            \"6:28\",            \"12:22\",            \"3:44\",            \"4:36\",            \"6:15\",            \"7:29\"        ],        [            \"21 - 25\",            \"5:09\",            \"6:29\",            \"12:23\",            \"3:45\",            \"4:38\",            \"6:16\",            \"7:30\"        ],        [            \"26 - 29\",            \"5:10\",            \"6:30\",            \"12:24\",            \"3:47\",            \"4:40\",            \"6:18\",            \"7:31\"        ],        [            \"30 - 31\",            \"5:11\",            \"6:30\",            \"12:25\",            \"3:47\",            \"4:42\",            \"6:19\",            \"7:32\"        ]    ],    \"feb\": [        [            \"1 - 6\",            \"5:11\",            \"6:30\",            \"12:26\",            \"3:48\",            \"4:42\",            \"6:20\",            \"7:32\"        ],        [            \"7 - 12\",            \"5:11\",            \"6:29\",            \"12:26\",            \"3:48\",            \"4:43\",            \"6:21\",            \"7:33\"        ],        [            \"13 - 17\",            \"5:11\",            \"6:28\",            \"12:26\",            \"3:47\",            \"4:44\",            \"6:22\",            \"7:33\"        ],        [            \"18 - 24\",            \"5:11\",            \"6:27\",            \"12:26\",            \"3:47\",            \"4:44\",            \"6:22\",            \"7:33\"        ],        [            \"25 - 29\",            \"5:09\",            \"6:25\",            \"12:25\",            \"3:45\",            \"4:43\",            \"6:23\",            \"7:33\"        ]    ],    \"mar\": [        [            \"1 - 4\",            \"5:08\",            \"6:24\",            \"12:24\",            \"3:42\",            \"4:43\",            \"6:22\",            \"7:32\"        ],        [            \"5 - 9\",            \"5:06\",            \"6:22\",            \"12:23\",            \"3:41\",            \"4:42\",            \"6:22\",            \"7:32\"        ],        [            \"10 - 13\",            \"5:04\",            \"6:20\",            \"12:22\",            \"3:38\",            \"4:41\",            \"6:22\",            \"7:32\"        ],        [            \"14 - 18\",            \"5:03\",            \"6:18\",            \"12:21\",            \"3:35\",            \"4:40\",            \"6:22\",            \"7:31\"        ],        [            \"19 - 20\",            \"5:01\",            \"6:16\",            \"12:20\",            \"3:33\",            \"4:38\",            \"6:22\",            \"7:31\"        ],        [            \"21 - 24\",            \"4:59\",            \"6:14\",            \"12:19\",            \"3:31\",            \"4:37\",            \"6:21\",            \"7:31\"        ],        [            \"25 - 27\",            \"4:57\",            \"6:13\",            \"12:18\",            \"3:28\",            \"4:36\",            \"6:21\",            \"7:31\"        ],        [            \"28 - 30\",            \"4:56\",            \"6:11\",            \"12:17\",            \"3:25\",            \"4:34\",            \"6:21\",            \"7:30\"        ],        [            \"31\",            \"4:54\",            \"6:10\",            \"12:16\",            \"3:22\",            \"4:33\",            \"6:20\",            \"7:30\"        ]    ],    \"apr\": [        [            \"1 - 2\",            \"4:53\",            \"6:10\",            \"12:16\",            \"3:21\",            \"4:33\",            \"6:20\",            \"7:30\"        ],        [            \"3 - 5\",            \"4:52\",            \"6:08\",            \"12:15\",            \"3:19\",            \"4:32\",            \"6:20\",            \"7:30\"        ],        [            \"6 - 11\",            \"4:50\",            \"6:07\",            \"12:14\",            \"3:16\",            \"4:30\",            \"6:19\",            \"7:30\"        ],        [            \"12 - 14\",            \"4:48\",            \"6:05\",            \"12:13\",            \"3:17\",            \"4:30\",            \"6:19\",            \"7:30\"        ],        [            \"15 - 18\",            \"4:46\",            \"6:03\",            \"12:12\",            \"3:19\",            \"4:31\",            \"6:19\",            \"7:30\"        ],        [            \"19 - 24\",            \"4:44\",            \"6:01\",            \"12:11\",            \"3:21\",            \"4:31\",            \"6:19\",            \"7:30\"        ],        [            \"25 - 29\",            \"4:41\",            \"5:59\",            \"12:10\",            \"3:23\",            \"4:31\",            \"6:19\",            \"7:30\"        ],        [            \"30\",            \"4:39\",            \"5:57\",            \"12:09\",            \"3:25\",            \"4:32\",            \"6:19\",            \"7:31\"        ]    ],    \"may\": [        [            \"1 - 3\",            \"4:38\",            \"5:57\",            \"12:09\",            \"3:26\",            \"4:32\",            \"6:19\",            \"7:31\"        ],        [            \"4 - 8\",            \"4:37\",            \"5:57\",            \"12:09\",            \"3:27\",            \"4:33\",            \"6:19\",            \"7:32\"        ],        [            \"9 - 14\",            \"4:35\",            \"5:55\",            \"12:08\",            \"3:28\",            \"4:34\",            \"6:20\",            \"7:33\"        ],        [            \"15 - 19\",            \"4:34\",            \"5:54\",            \"12:08\",            \"3:30\",            \"4:34\",            \"6:20\",            \"7:34\"        ],        [            \"20 - 25\",            \"4:33\",            \"5:54\",            \"12:08\",            \"3:32\",            \"4:35\",            \"6:21\",            \"7:36\"        ],        [            \"26 - 28\",            \"4:32\",            \"5:53\",            \"12:09\",            \"3:34\",            \"4:37\",            \"6:22\",            \"7:38\"        ],        [            \"29 - 31\",            \"4:32\",            \"5:54\",            \"12:09\",            \"3:35\",            \"4:38\",            \"6:23\",            \"7:39\"        ]    ],    \"jun\": [        [            \"1 - 6\",            \"4:32\",            \"5:54\",            \"12:10\",            \"3:36\",            \"4:38\",            \"6:24\",            \"7:40\"        ],        [            \"7 - 10\",            \"4:31\",            \"5:54\",            \"12:11\",            \"3:38\",            \"4:40\",            \"6:25\",            \"7:42\"        ],        [            \"11 - 14\",            \"4:31\",            \"5:55\",            \"12:11\",            \"3:39\",            \"4:41\",            \"6:26\",            \"7:43\"        ],        [            \"15 - 17\",            \"4:32\",            \"5:55\",            \"12:12\",            \"3:39\",            \"4:41\",            \"6:27\",            \"7:44\"        ],        [            \"18 - 20\",            \"4:32\",            \"5:56\",            \"12:13\",            \"3:40\",            \"4:42\",            \"6:28\",            \"7:44\"        ],        [            \"21 - 25\",            \"4:33\",            \"5:57\",            \"12:14\",            \"3:41\",            \"4:43\",            \"6:29\",            \"7:45\"        ],        [            \"26 - 30\",            \"4:34\",            \"5:58\",            \"12:15\",            \"3:42\",            \"4:44\",            \"6:30\",            \"7:47\"        ]    ],    \"jul\": [        [            \"1 - 6\",            \"4:35\",            \"5:59\",            \"12:16\",            \"3:43\",            \"4:45\",            \"6:31\",            \"7:47\"        ],        [            \"7 - 10\",            \"4:37\",            \"6:00\",            \"12:17\",            \"3:44\",            \"4:46\",            \"6:32\",            \"7:48\"        ],        [            \"11 - 18\",            \"4:39\",            \"6:01\",            \"12:17\",            \"3:44\",            \"4:46\",            \"6:32\",            \"7:48\"        ],        [            \"19 - 23\",            \"4:41\",            \"6:03\",            \"12:18\",            \"3:43\",            \"4:46\",            \"6:32\",            \"7:47\"        ],        [            \"24 - 29\",            \"4:42\",            \"6:03\",            \"12:18\",            \"3:42\",            \"4:45\",            \"6:31\",            \"7:46\"        ],        [            \"30 - 31\",            \"4:43\",            \"6:04\",            \"12:18\",            \"3:40\",            \"4:44\",            \"6:31\",            \"7:44\"        ]    ],    \"aug\": [        [            \"1 - 4\",            \"4:44\",            \"6:04\",            \"12:18\",            \"3:39\",            \"4:44\",            \"6:31\",            \"7:44\"        ],        [            \"5 - 9\",            \"4:45\",            \"6:05\",            \"12:18\",            \"3:38\",            \"4:43\",            \"6:29\",            \"7:43\"        ],        [            \"10 - 14\",            \"4:45\",            \"6:04\",            \"12:17\",            \"3:35\",            \"4:41\",            \"6:27\",            \"7:40\"        ],        [            \"15 - 19\",            \"4:46\",            \"6:04\",            \"12:16\",            \"3:31\",            \"4:39\",            \"6:26\",            \"7:38\"        ],        [            \"20 - 23\",            \"4:46\",            \"6:04\",            \"12:15\",            \"3:28\",            \"4:37\",            \"6:24\",            \"7:36\"        ],        [            \"24 - 26\",            \"4:46\",            \"6:04\",            \"12:14\",            \"3:25\",            \"4:34\",            \"6:22\",            \"7:34\"        ],        [            \"27 - 29\",            \"4:47\",            \"6:04\",            \"12:13\",            \"3:22\",            \"4:33\",            \"6:21\",            \"7:32\"        ],        [            \"30 - 31\",            \"4:47\",            \"6:03\",            \"12:13\",            \"3:19\",            \"4:31\",            \"6:19\",            \"7:30\"        ]    ],    \"sep\": [        [            \"1\",            \"4:47\",            \"6:03\",            \"12:12\",            \"3:16\",            \"4:31\",            \"6:18\",            \"7:29\"        ],        [            \"2 - 4\",            \"4:47\",            \"6:03\",            \"12:12\",            \"3:16\",            \"4:29\",            \"6:18\",            \"7:28\"        ],        [            \"5 - 8\",            \"4:47\",            \"6:03\",            \"12:11\",            \"3:13\",            \"4:27\",            \"6:16\",            \"7:27\"        ],        [            \"9 - 11\",            \"4:46\",            \"6:02\",            \"12:09\",            \"3:13\",            \"4:26\",            \"6:14\",            \"7:25\"        ],        [            \"12 - 14\",            \"4:46\",            \"6:02\",            \"12:08\",            \"3:14\",            \"4:25\",            \"6:13\",            \"7:23\"        ],        [            \"15 - 17\",            \"4:45\",            \"6:01\",            \"12:07\",            \"3:14\",            \"4:24\",            \"6:11\",            \"7:21\"        ],        [            \"18 - 22\",            \"4:45\",            \"6:00\",            \"12:06\",            \"3:15\",            \"4:24\",            \"6:09\",            \"7:19\"        ],        [            \"23 - 26\",            \"4:44\",            \"6:00\",            \"12:04\",            \"3:16\",            \"4:23\",            \"6:07\",            \"7:17\"        ],        [            \"27 - 30\",            \"4:44\",            \"5:59\",            \"12:03\",            \"3:16\",            \"4:21\",            \"6:05\",            \"7:14\"        ]    ],    \"oct\": [        [            \"1 - 2\",            \"4:43\",            \"5:59\",            \"12:02\",            \"3:16\",            \"4:20\",            \"6:03\",            \"7:12\"        ],        [            \"3 - 6\",            \"4:43\",            \"5:58\",            \"12:01\",            \"3:16\",            \"4:20\",            \"6:01\",            \"7:11\"        ],        [            \"7 - 8\",            \"4:42\",            \"5:58\",            \"12:00\",            \"3:16\",            \"4:19\",            \"5:59\",            \"7:09\"        ],        [            \"9 - 13\",            \"4:42\",            \"5:58\",            \"11:59\",            \"3:16\",            \"4:18\",            \"5:58\",            \"7:08\"        ],        [            \"14 - 16\",            \"4:41\",            \"5:57\",            \"11:58\",            \"3:16\",            \"4:16\",            \"5:56\",            \"7:06\"        ],        [            \"17 - 22\",            \"4:41\",            \"5:57\",            \"11:57\",            \"3:16\",            \"4:15\",            \"5:55\",            \"7:05\"        ],        [            \"23 - 31\",            \"4:41\",            \"5:57\",            \"11:56\",            \"3:17\",            \"4:15\",            \"5:53\",            \"7:04\"        ]    ],    \"nov\": [        [            \"1 - 7\",            \"4:41\",            \"5:59\",            \"11:56\",            \"3:17\",            \"4:14\",            \"5:51\",            \"7:03\"        ],        [            \"8 - 15\",            \"4:41\",            \"6:00\",            \"11:56\",            \"3:18\",            \"4:13\",            \"5:50\",            \"7:02\"        ],        [            \"16 - 21\",            \"4:42\",            \"6:02\",            \"11:57\",            \"3:19\",            \"4:13\",            \"5:50\",            \"7:03\"        ],        [            \"22 - 24\",            \"4:43\",            \"6:03\",            \"11:58\",            \"3:20\",            \"4:13\",            \"5:51\",            \"7:04\"        ],        [            \"25 - 27\",            \"4:45\",            \"6:05\",            \"11:59\",            \"3:21\",            \"4:14\",            \"5:51\",            \"7:05\"        ],        [            \"28 - 30\",            \"4:45\",            \"6:06\",            \"12:00\",            \"3:22\",            \"4:14\",            \"5:52\",            \"7:06\"        ]    ],    \"dec\": [        [            \"1 - 3\",            \"4:47\",            \"6:08\",            \"12:01\",            \"3:23\",            \"4:16\",            \"5:53\",            \"7:07\"        ],        [            \"4 - 6\",            \"4:48\",            \"6:09\",            \"12:02\",            \"3:24\",            \"4:17\",            \"5:54\",            \"7:08\"        ],        [            \"7 - 9\",            \"4:49\",            \"6:10\",            \"12:04\",            \"3:25\",            \"4:17\",            \"5:55\",            \"7:09\"        ],        [            \"10 - 11\",            \"4:50\",            \"6:12\",            \"12:05\",            \"3:26\",            \"4:18\",            \"5:56\",            \"7:11\"        ],        [            \"12 - 14\",            \"4:51\",            \"6:13\",            \"12:06\",            \"3:28\",            \"4:20\",            \"5:57\",            \"7:12\"        ],        [            \"15 - 16\",            \"4:53\",            \"6:15\",            \"12:07\",            \"3:29\",            \"4:21\",            \"5:58\",            \"7:14\"        ],        [            \"17 - 18\",            \"4:54\",            \"6:15\",            \"12:08\",            \"3:30\",            \"4:22\",            \"5:59\",            \"7:14\"        ],        [            \"19 - 20\",            \"4:54\",            \"6:16\",            \"12:09\",            \"3:30\",            \"4:22\",            \"6:00\",            \"7:15\"        ],        [            \"21\",            \"4:56\",            \"6:18\",            \"12:10\",            \"3:32\",            \"4:24\",            \"6:01\",            \"7:16\"        ],        [            \"22 - 25\",            \"4:56\",            \"6:18\",            \"12:11\",            \"3:32\",            \"4:24\",            \"6:02\",            \"7:17\"        ],        [            \"26 - 27\",            \"4:57\",            \"6:19\",            \"12:13\",            \"3:33\",            \"4:25\",            \"6:03\",            \"7:18\"        ],        [            \"28 - 29\",            \"4:59\",            \"6:21\",            \"12:14\",            \"3:35\",            \"4:27\",            \"6:04\",            \"7:19\"        ],        [            \"30 - 31\",            \"5:00\",            \"6:22\",            \"12:15\",            \"3:36\",            \"4:28\",            \"6:05\",            \"7:20\"        ]    ]}";

        private static readonly string[] s_shortMonths = { "jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec" };

        private readonly DateTime _displayDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        private List<List<string>> _prayTimeForToday;

        private DateTime _timeNow = DateTime.Now;

        public MainPage()
        {
            InitializeComponent();

            DisplayMonth = _displayDate.ToString("MMMM, yyyy");
            var shortDisplayMonth = s_shortMonths[_displayDate.Month - 1];
            PrayTimeForToday = _prayTimes[shortDisplayMonth];
        }

        private string _displayMonth;

        public string DisplayMonth
        {
            get => _displayMonth;
            set
            {
                if (_displayMonth != value)
                {
                    _displayMonth = value;
                    OnPropertyChanged(nameof(DisplayMonth));
                }
            }
        }

        public List<List<int?>> Weeks { get; set; } = new List<List<int?>>
        {
            // @formatter:off
            new List<int?> { null, 1, 2, 3, 4, 5, 6 },
            new List<int?> { 7, 8, 9, 10, 11, 12, 13 },
            new List<int?> { 14, 15, 16, 17, 18, 19, 20 },
            new List<int?> { 21, 22, 23, 24, 25, 26, 27 },
            new List<int?> { 28, 29, 30, 31, null, null, null }
            // @formatter:on
        };

        public List<List<string>> PrayTimeForToday
        {
            get => _prayTimeForToday;
            set
            {
                if (_prayTimeForToday != value)
                {
                    _prayTimeForToday = value;
                    OnPropertyChanged(nameof(PrayTimeForToday));
                }
            }
        }

        private Dictionary<string, List<List<string>>> _prayTimes { get; } =
            JsonConvert.DeserializeObject<Dictionary<string, List<List<string>>>>(_rawPrayTimes);
    }
}