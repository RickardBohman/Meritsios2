using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Meritsios_2._0.Pages.Feed
{
    public class DashboardModel : PageModel
    {

        private FirestoreDb _db;
        public List<Dictionary<string, object>> Posts { get; set; }

        public DashboardModel()
        {
            string filePath =
                "./meritsios2-firebase-adminsdk-seo92-ec9db2b4c7.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _db = FirestoreDb.Create("meritsios2");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string content = Request.Form["postContent"];
            var post = new Dictionary<string, object>
            {
                {"Content", content},
                {"createdAt", DateTime.UtcNow}
            };
            await _db.Collection("posts").AddAsync(post);

            return RedirectToPage("");
        }


        public async Task OnGetAsync()
        {
            var postRef = _db.Collection("posts");
            var query = await postRef.OrderByDescending("createdAt").GetSnapshotAsync();
            Posts = query.Documents.Select(d => d.ToDictionary()).ToList();
        }
    }
}
