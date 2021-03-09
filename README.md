# UntappdMenuHelper
a helper to get Untappd menu pieces.

Untappd
- https://untappd.com/api/docs
- https://docs.business.untappd.com/#introduction

You need to generate an access token, which consists of a user email and an API key


Once you have your API key and a user for the Untappd menu with API access, you can use the UntappdMenuHelper, powered by UntappdNet to get your menu's.

First, create the byte array, this is your access token
- var byteArray = Encoding.ASCII.GetBytes($"{UntappdAdminEmail}:{UntappdAdminApiKey}");

Once your access token is created, you can start to use the UntappdMenuHelper to get your menu pieces

Instantiate a service:
- private readonly UntappdMenuJSON.UntappdService _untappdMenuService = new UntappdService();

then use the service to get:
Location Data
- _untappdMenuService.GetLocationCollection(byteArray).Result;

Menu's by location
- _untappdMenuService.GetMenuCollectionByLocation(byteArray, location.Id.GetValueOrDefault()).Result;

Annoucements by location
- _untappdMenuService.GetMenuAnnouncementCollectionByLocation(byteArray, location.Id.GetValueOrDefault()).Result;

Sections by menu
- _untappdMenuService.GetSectionCollectionByMenu(byteArray, menu.Id.GetValueOrDefault()).Result;

NOTE:
This is not a speedy service by any means, so using this in real time is probably a bad idea. We recommend storing the data you get somewhere and then accessed real time after
it is already built. We have a job that runs daily to update the stored JSON and then we construct menu's based on the stored data depending what Location, Menu or Sections an
end user wants to show.
