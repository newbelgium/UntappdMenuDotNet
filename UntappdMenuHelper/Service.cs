using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UntappdMenuHelper
{
    /// <summary>
    /// Collection of tasks that can be performed to get menuu's by a location id
    /// </summary>
    public interface IUntappdService
    {
        Task<UntappdLocation> GetLocationCollection(byte[] byteArray);
        Task<UntappdMenus> GetMenuCollectionByLocation(byte[] byteArray, long locationId);
        Task<UntappdMenuAnnouncements> GetMenuAnnouncementCollectionByLocation(byte[] byteArray, long locationId);
        Task<UntappdMenuSections> GetSectionCollectionByMenu(byte[] byteArray, long menuId);
        Task<UntappdMenuItems> GetItemCollectionBySection(byte[] byteArray, long sectionId);
        Task<UntappdMenuItemContainers> GetItemContainersCollectionByItem(byte[] byteArray, long itemId);
    }

    public class UntappdService : IUntappdService
    {
        /// <summary>
        /// By user, get a collection of locations that the user can read/write to
        /// </summary>
        /// <returns>Collection of locations based on the authenticated user</returns>
        public async Task<UntappdLocation> GetLocationCollection(byte[] byteArray)
        {
            Uri uri = new Uri("https://business.untappd.com/api/v1/locations");
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            HttpResponseMessage response = await client.GetAsync(uri);
            HttpContent content = response.Content;

            return await content.ReadAsAsync<UntappdLocation>();
        }

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
    }
}