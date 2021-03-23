using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UntappdMenuDotNet
{
    /// <summary>
    /// Collection of tasks that can be performed to get menus by a location id
    /// </summary>
    public interface IUntappdService
    {
        Task<UntappdLocationCollection> GetLocationCollection();
        Task<UntappdMenus> GetMenuCollectionByLocation(long locationId);
        Task<UntappdMenuAnnouncements> GetMenuAnnouncementCollectionByLocation(long locationId);
        Task<UntappdMenuSections> GetSectionCollectionByMenu(long menuId);
        Task<UntappdMenuItems> GetItemCollectionBySection(long sectionId);
        Task<UntappdMenuItemContainers> GetItemContainersCollectionByItem(long itemId);

        #region obsolete
        [Obsolete("instantiate service with credentials and call methods without byte array", true)]
        Task<UntappdLocationCollection> GetLocationCollection(byte[] byteArray);
        [Obsolete("instantiate service with credentials and call methods without byte array", true)]
        Task<UntappdMenus> GetMenuCollectionByLocation(byte[] byteArray, long locationId);
        [Obsolete("instantiate service with credentials and call methods without byte array", true)]
        Task<UntappdMenuAnnouncements> GetMenuAnnouncementCollectionByLocation(byte[] byteArray, long locationId);
        [Obsolete("instantiate service with credentials and call methods without byte array", true)]
        Task<UntappdMenuSections> GetSectionCollectionByMenu(byte[] byteArray, long menuId);
        [Obsolete("instantiate service with credentials and call methods without byte array", true)]
        Task<UntappdMenuItems> GetItemCollectionBySection(byte[] byteArray, long sectionId);
        [Obsolete("instantiate service with credentials and call methods without byte array", true)]
        Task<UntappdMenuItemContainers> GetItemContainersCollectionByItem(byte[] byteArray, long itemId);
        #endregion
    }

    public class UntappdService : IUntappdService
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient _client = new HttpClient();

        private readonly string urlBase = "https://business.untappd.com/api";
        private readonly string apiVersion = "v1";

        private void SetUserCredentials(byte[] value)
        {
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(value));
        }

        public UntappdService(byte[] userCredentials)
        {
            SetUserCredentials(userCredentials ?? throw new ArgumentNullException(nameof(userCredentials)));
        }

        public UntappdService(string username, string apitoken)
        {
            if (username == null)
                throw new ArgumentNullException(username);
            if (apitoken == null)
                throw new ArgumentNullException(apitoken);

            SetUserCredentials(Encoding.ASCII.GetBytes($"{username}:{apitoken}"));
        }

        private async Task<T> Get<T>(string resource)
        {
            Uri uri = new Uri($"{urlBase}/{apiVersion}/{resource}");
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                HttpContent content = response.Content;
                return await content.ReadAsAsync<T>();
            }
            else
            {
                var error = await response.Content.ReadAsAsync<UntappdError>();
                throw new UntappdException($"Error occurred.  Code: {response.StatusCode}. Reason: {response.ReasonPhrase}", error);
            }
        }

        public async Task<UntappdLocationCollection> GetLocationCollection()
        {
            return await Get<UntappdLocationCollection>("locations");
        }

        /// <summary>
        /// By location and authenticated user, get the locations menu
        /// </summary>
        /// <returns>Collection of menu's</returns>
        public async Task<UntappdMenus> GetMenuCollectionByLocation(long locationId)
        {
            return await Get<UntappdMenus>($"locations/{locationId}/menus");
        }

        /// <summary>
        /// By location and authenticated user, get the menue annoucements for that location. Call outs to new items, deals, etc.
        /// </summary>
        /// <returns>Collection of menu annoucements</returns>
        public async Task<UntappdMenuAnnouncements> GetMenuAnnouncementCollectionByLocation(long locationId)
        {
            return await Get<UntappdMenuAnnouncements>($"locations/{locationId}/menu_announcements");
        }

        /// <summary>
        /// By menu and authenticated user, get the menu sections. Each menu has different sections (IPA's, Sours, Ale's) to be rendered for end users.
        /// </summary>
        /// <returns>Collection of sections for a menu.</returns>
        public async Task<UntappdMenuSections> GetSectionCollectionByMenu(long menuId)
        {
            return await Get<UntappdMenuSections>($"menus/{menuId}/sections");
        }

        /// <summary>
        /// By Sesion and Authenticated user, get the items in the menu section. Each  item represents a beer on tap.
        /// </summary>
        /// <returns>Collection of items in a section</returns>
        public async Task<UntappdMenuItems> GetItemCollectionBySection(long sectionId)
        {
            return await Get<UntappdMenuItems>($"sections/{sectionId}/items");
        }

        /// <summary>
        /// By item and authenticated user, get the item details. Price, size, etc stored here.
        /// </summary>
        /// <returns>Collection of item containers</returns>
        public async Task<UntappdMenuItemContainers> GetItemContainersCollectionByItem(long itemId)
        {
            return await Get<UntappdMenuItemContainers>($"items/{itemId}/containers");
        }

        #region OBSOLETE
        [Obsolete("no more paramaterless constructor", true)]
        public UntappdService() { }
        [Obsolete("instantiate service with credentials and call methods without byte array", true)]
        /// <summary>
        /// By user, get a collection of locations that the user can read/write to
        /// </summary>
        /// <returns>Collection of locations based on the authenticated user</returns>
        /// 
        public async Task<UntappdLocationCollection> GetLocationCollection(byte[] byteArray)
        {
            Uri uri = new Uri("https://business.untappd.com/api/v1/locations");
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            HttpResponseMessage response = await client.GetAsync(uri);
            HttpContent content = response.Content;

            return await content.ReadAsAsync<UntappdLocationCollection>();
        }
        [Obsolete("instantiate service with credentials and call methods without byte array", true)]
        /// <summary>
        /// By location and authenticated user, get the locations menu
        /// </summary>
        /// <returns>Collection of menu's</returns>
        public async Task<UntappdMenus> GetMenuCollectionByLocation(byte[] byteArray, long locationId)
        {
            Uri uri = new Uri(string.Format("https://business.untappd.com/api/v1/locations/{0}/menus", locationId));
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            HttpResponseMessage response = await client.GetAsync(uri);
            HttpContent content = response.Content;

            return await content.ReadAsAsync<UntappdMenus>();
        }
        [Obsolete("instantiate service with credentials and call methods without byte array", true)]
        /// <summary>
        /// By location and authenticated user, get the menue annoucements for that location. Call outs to new items, deals, etc.
        /// </summary>
        /// <returns>Collection of menu annoucements</returns>
        public async Task<UntappdMenuAnnouncements> GetMenuAnnouncementCollectionByLocation(byte[] byteArray, long locationId)
        {
            Uri uri = new Uri(string.Format("https://business.untappd.com/api/v1/locations/{0}/menu_announcements", locationId));
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            HttpResponseMessage response = await client.GetAsync(uri);
            HttpContent content = response.Content;

            return await content.ReadAsAsync<UntappdMenuAnnouncements>();
        }
        [Obsolete("instantiate service with credentials and call methods without byte array", true)]
        /// <summary>
        /// By menu and authenticated user, get the menu sections. Each menu has different sections (IPA's, Sours, Ale's) to be rendered for end users.
        /// </summary>
        /// <returns>Collection of sections for a menu.</returns>
        public async Task<UntappdMenuSections> GetSectionCollectionByMenu(byte[] byteArray, long menuId)
        {
            Uri uri = new Uri(string.Format("https://business.untappd.com/api/v1/menus/{0}/sections", menuId));
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            HttpResponseMessage response = await client.GetAsync(uri);
            HttpContent content = response.Content;

            return await content.ReadAsAsync<UntappdMenuSections>();
        }
        [Obsolete("instantiate service with credentials and call methods without byte array", true)]
        /// <summary>
        /// By Sesion and Authenticated user, get the items in the menu section. Each  item represents a beer on tap.
        /// </summary>
        /// <returns>Collection of items in a section</returns>
        public async Task<UntappdMenuItems> GetItemCollectionBySection(byte[] byteArray, long sectionId)
        {
            Uri uri = new Uri(string.Format("https://business.untappd.com/api/v1/sections/{0}/items", sectionId));
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            HttpResponseMessage response = await client.GetAsync(uri);
            HttpContent content = response.Content;

            return await content.ReadAsAsync<UntappdMenuItems>();
        }
        [Obsolete("instantiate service with credentials and call methods without byte array", true)]
        /// <summary>
        /// By item and authenticated user, get the item details. Price, size, etc stored here.
        /// </summary>
        /// <returns>Collection of item containers</returns>
        public async Task<UntappdMenuItemContainers> GetItemContainersCollectionByItem(byte[] byteArray, long itemId)
        {
            Uri uri = new Uri(string.Format("https://business.untappd.com/api/v1/items/{0}/containers", itemId));
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            HttpResponseMessage response = await client.GetAsync(uri);
            HttpContent content = response.Content;

            return await content.ReadAsAsync<UntappdMenuItemContainers>();
        }
        #endregion
    }
}