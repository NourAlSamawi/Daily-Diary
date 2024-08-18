using DiaryManager;

namespace DiaryManagerTests
{
    public class UnitTest1
    {
        private readonly string testFilePath = Path.Combine(Environment.CurrentDirectory, "testDiary.txt");

        public UnitTest1()
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [Fact]
        public void TestAddEntry()
        {
            DailyDiary diary = new DailyDiary(testFilePath);
            diary.AddEntry(new Entry(DateTime.Now, "Test entry"));

            Assert.Equal(1, diary.CountLines());
        }

        [Fact]
        public void TestReadDiaryFile()
        {
            DailyDiary diary = new DailyDiary(testFilePath);
            diary.AddEntry(new Entry(DateTime.Now, "Test entry"));

            var entries = diary.ReadDiaryFile();
            Assert.Single(entries);
        }

        [Fact]
        public void TestDeleteEntry()
        {
            DailyDiary diary = new DailyDiary(testFilePath);
            DateTime date = DateTime.Now;
            diary.AddEntry(new Entry(date, "Test entry"));

            diary.DeleteEntry(date);

            Assert.Empty(diary.ReadDiaryFile());
        }

        [Fact]
        public void TestSearchByDate()
        {
            DailyDiary diary = new DailyDiary(testFilePath);
            DateTime date = DateTime.Now;
            diary.AddEntry(new Entry(date, "Test entry"));

            var searchResults = diary.SearchByDate(date);
            Assert.Single(searchResults);
        }

        [Fact]
        public void TestSearchByKeyword()
        {
            DailyDiary diary = new DailyDiary(testFilePath);
            diary.AddEntry(new Entry(DateTime.Now, "Test entry"));

            var searchResults = diary.SearchByKeyword("Test");
            Assert.Single(searchResults);
        }
    }
}