using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using ProjectEulerDataContracts;
using ProjectEulerLib;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ProjectEulerWebAPI.Controllers
{
    [ApiController]
    public class FocusTopicController : ControllerBase
    {
        /*
            focus 25 minutes each
                3 X 7:30 - 9:15
                5 X 1:00 - 4:00
                2 X 7:00 - 8:30

            Life skills (5)
                c# (10), react(10), azure(10), javascript(5), database(3)
            Computer science (3)
                classic computer books (10), data structure, algorithm, web development, new language
            General Interests (2)
                science, math, physics, chemistry, history, French, music, architecture, phycology, engineering, nature, trails, bike repair
            https://localhost:5001/FocusTimes
        */
        private readonly ILogger<FocusTopicController> _logger;

        public FocusTopicController(ILogger<FocusTopicController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("/FocusTimes")]
        public ActionResult<List<Schedule>> GenerateSchedule()
        {

            try
            {
                List<Category> categories = InitializeCategories();
                List<Topic> topics = InitializeTopics();
                List<TimeSlot> timeSlots = InitializeTimeSlots();
                List<Schedule> schedules = new List<Schedule>();
                
                List<Topic> topicsInCategories = new List<Topic>();
                foreach(int categoryId in categories.Select(c => c.CategoryId))
                    topicsInCategories.AddRange(GetWeightedTopicsByCartegory(categoryId, topics));
                
                List<int> categoryIdForEachTimeSlot = PickCategoryIdForEachTimeSlot(categories);

                for(int timeSlotId = 1; timeSlotId <= 10; timeSlotId ++)
                {
                    int categoryId = categoryIdForEachTimeSlot[timeSlotId - 1];
                    
                    Category category = categories.FirstOrDefault(c => c.CategoryId == categoryId);
                    TimeSlot timeSlot = timeSlots[timeSlotId - 1];


                    List<Topic> weightedTopics = topicsInCategories.Where(ct => ct.CategoryId == categoryId).ToList();

                    Random rnd = new Random();
                    int topicIndex = rnd.Next(0, weightedTopics.Count);

                    Topic wt = weightedTopics[topicIndex];

                    Schedule schedule = new Schedule{
                        TopicId = wt.TopicId,
                        CategoryId = wt.CategoryId,
                        CategoryName = category.Name,
                        TopicName = wt.Name,
                        TimeSlot = timeSlot.StartTime + " to " + timeSlot.EndTime,
                        TimeSlotId = timeSlot.TimeSlotId
                    };

                    schedules.Add(schedule);
                }

                return Ok(schedules);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("FocusTimes", ex.Message);
                return BadRequest(ModelState);
            }
        }

        List<Category> InitializeCategories()
        {
            return new List<Category>{
                new Category {
                    CategoryId = 1,
                    Name = "Life Skills",
                    Weight = 5
                },
                new Category {
                    CategoryId = 2,
                    Name = "Computer Science",
                    Weight = 3
                },
                new Category {
                    CategoryId = 3,
                    Name = "General Interests",
                    Weight = 2
                }
            };
        }

        List<int> PickCategoryIdForEachTimeSlot(List<Category> allCategories)
        {
            List<Category> categories = new List<Category>();
            categories.AddRange(allCategories);

            List<int> categoryIdForEachTimeSlot = new List<int>();

            for(int i = 0; i < 10; i ++)
            {
                Random rnd = new Random();
                int categoryIdIndex = rnd.Next(0, categories.Count);
                int categoryId = categories[categoryIdIndex].CategoryId;
                categoryIdForEachTimeSlot.Add(categoryId);
                if (categoryIdForEachTimeSlot.Where(ct => ct == categoryId).Count() == categories.FirstOrDefault(c => c.CategoryId == categoryId).Weight)
                {
                    categories.Remove(categories.FirstOrDefault(c => c.CategoryId == categoryId));
                }
            }

            return categoryIdForEachTimeSlot;
        }

        List<TimeSlot> InitializeTimeSlots()
        {
            return new List<TimeSlot> {
                new TimeSlot{
                    TimeSlotId = 1,
                    StartTime = "07:30",
                    EndTime = "09:15"
                },
                new TimeSlot{
                    TimeSlotId = 2,
                    StartTime = "07:30",
                    EndTime = "09:15"
                },
                new TimeSlot{
                    TimeSlotId = 3,
                    StartTime = "07:30",
                    EndTime = "09:15"
                },
                new TimeSlot{
                    TimeSlotId = 4,
                    StartTime = "13:00",
                    EndTime = "16:00"
                },
                new TimeSlot{
                    TimeSlotId = 5,
                    StartTime = "13:00",
                    EndTime = "16:00"
                },
                new TimeSlot{
                    TimeSlotId = 6,
                    StartTime = "13:00",
                    EndTime = "16:00"
                },
                new TimeSlot{
                    TimeSlotId = 7,
                    StartTime = "13:00",
                    EndTime = "16:00"
                },
                new TimeSlot{
                    TimeSlotId = 8,
                    StartTime = "13:00",
                    EndTime = "16:00"
                },
                new TimeSlot{
                    TimeSlotId = 9,
                    StartTime = "19:00",
                    EndTime = "20:30"
                },
                new TimeSlot{
                    TimeSlotId = 10,
                    StartTime = "19:00",
                    EndTime = "20:30"
                },
            };
        }

        List<Topic> InitializeTopics()
        {
            return new List<Topic>{
                new Topic { CategoryId = 1, TopicId = 1, Name = "DotNet", Weight = 10},
                new Topic { CategoryId = 1, TopicId = 2, Name = "React", Weight = 10},
                new Topic { CategoryId = 1, TopicId = 3, Name = "Azure", Weight = 10},
                new Topic { CategoryId = 1, TopicId = 4, Name = "Javascript", Weight = 3},
                new Topic { CategoryId = 1, TopicId = 5, Name = "Sql Server", Weight = 3},
                new Topic { CategoryId = 2, TopicId = 6, Name = "Classic Books", Weight = 10},
                new Topic { CategoryId = 2, TopicId = 7, Name = "Data Structure", Weight = 3},
                new Topic { CategoryId = 2, TopicId = 7, Name = "Algorithm", Weight = 3},
                new Topic { CategoryId = 2, TopicId = 8, Name = "Web Development", Weight = 1},
                new Topic { CategoryId = 2, TopicId = 10, Name = "New Programming Language", Weight = 3},
                new Topic { CategoryId = 3, TopicId = 11, Name = "Nuro Science", Weight = 1},
                new Topic { CategoryId = 3, TopicId = 12, Name = "Cosmology", Weight = 1},
                new Topic { CategoryId = 3, TopicId = 13, Name = "Math", Weight = 1},
                new Topic { CategoryId = 3, TopicId = 14, Name = "Physics", Weight = 1},
                new Topic { CategoryId = 3, TopicId = 15, Name = "Chemistry", Weight = 1},
                new Topic { CategoryId = 3, TopicId = 16, Name = "History", Weight = 1},
                new Topic { CategoryId = 3, TopicId = 17, Name = "Language", Weight = 1},
                new Topic { CategoryId = 3, TopicId = 18, Name = "Music History", Weight = 1},
                new Topic { CategoryId = 3, TopicId = 19, Name = "Architecture", Weight = 1},
                new Topic { CategoryId = 3, TopicId = 20, Name = "Psycology", Weight = 1},
                new Topic { CategoryId = 3, TopicId = 21, Name = "Nature", Weight = 1},
                new Topic { CategoryId = 3, TopicId = 22, Name = "Trails", Weight = 1},
                new Topic { CategoryId = 3, TopicId = 23, Name = "Bike Repair", Weight = 1},
            };
        }

        List<Topic> GetWeightedTopicsByCartegory(int categoryId, List<Topic> allTopics)
        {
            var topics = allTopics.Where(t => t.CategoryId == categoryId);
            List<Topic> topicsInCategory = new List<Topic>();
            foreach(Topic topic in topics)
                for(int i = 0; i < topic.Weight; i ++)
                    topicsInCategory.Add(topic);

            return topicsInCategory;            
        }
    }

    public class Schedule
    {
        public int CategoryId { get; set;}
        public int TopicId { get; set;}
        
        public int TimeSlotId { get; set;}

        public string CategoryName { get; set; }

        public string TopicName { get; set; }

        public string TimeSlot { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }
    }

    public class Topic
    {
        public int CategoryId { get; set; }

        public int TopicId { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }
    }

    public class TimeSlot 
    {
        public int TimeSlotId {get;set;}

        public string StartTime {get;set;}

        public string EndTime {get;set;}

    }

}