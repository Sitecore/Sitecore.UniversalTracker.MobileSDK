Sitecore UniversalTracker SDK
========

Sitecore Universal Tracker SDK 1.0 is a .Net Standard that provides the interactions and events writing API for client .NET applications. The Universal Tracker SDK serves as an interface that connects the Universal Tracker service and an application to let users work with native objects rather than with HTTP requests and JSON responses.

* event		
* goal		
* outcome	
* pageview	
* campaign	
* download	
* search		

The library can be used on the following platforms :

* iOS 10 and newer
* Android 4.0 and newer
* Windows Desktop (.NET 4.5)

# Downloads
- [NuGet packages](https://www.nuget.org/packages/Sitecore.UniversalTracker.MobileSDK)

# Links
- [Documentation](https://doc.sitecore.com/developers/91/sitecore-experience-platform/en/universal-tracker-sdk.html)
- [iOS Sample](https://github.com/Sitecore/Sitecore.UniversalTracker.MobileSDK/tree/master/Sitecore.UniversalTrackerClient/Apps/Demo/UniversalTrackerDemo)



# Code Snippet
```csharp
  string instanceUrl = "http://my.site.com";
  string channelId = "27b4e611-a73d-4a95-b20a-811d295bdf65";
  string definitionId = "01f8ffbf-d662-4a87-beee-413307055c48";

  var defaultInteraction = UTEntitiesBuilder.Interaction()
                                           .ChannelId(channelId)
                                           .Initiator(InteractionInitiator.Contact)
                                           .Contact("jsdemo", "demo")
                                           .Build();

  using (session = SitecoreUTSessionBuilder.SessionWithHost(instanceUrl)
                                           .DefaultInteraction(defaultInteraction)
                                           .BuildSession()
        )
  {
    
    var eventRequest = UTRequestBuilder.EventWithDefinitionId(definitionId)
                                      .Build();
   
    var eventResponse = await session.TrackEventAsync(eventRequest);
   
    Console.WriteLine("Track EVENT RESULT: " + eventResponse.StatusCode.ToString());

        var okAlertController = UIAlertController.Create("Event response code",
            eventResponse.StatusCode.ToString(), 
            UIAlertControllerStyle.Alert);
         okAlertController.AddAction(UIAlertAction.Create("OK",
            UIAlertActionStyle.Default, 
            alert => Console.WriteLine("Ok")))

     PresentViewController(okAlertController, true, null);

   }
```
