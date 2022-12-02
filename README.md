# phoenix social
Open source social media service that enables occupation, brand, and public square elements with self-moderation and paid advertising and features.

## Collaboration Needs

* Front-end design
* Front-end developer with Web Assembly expertise
* AWS Engineer preferably with Graph Database experience, specifically Neo4j
* Community members to create guidelines, moderation policies
* Funding with intent to inflate as a 503c - non-profit

## Vision
Phoenix Social will look similar to Twitter with major changes and features. All users would be rated with a "karma" attribute similar to Reddit and new accounts would have to earn karma to post media and links and to have posts viewable by more than their immediate followers. DM access would be restricted to accounts with a "high" level of karma. If an account has no followers, their only action is to follow and like posts, hoping other people see their bio and follow back. Users will be able to manage multiple timelines with access to basic filtering and sorting capabilities. Paid accounts will have broader access to these tools.

### Accounts
#### Creation
New accounts would request a handle and optionally verify that handle via a Twitter post with a given phrase (as long as Twitter stands, we will check for handles there and prevent re-use on our platform).

#### Official Label
Once an account is created, the user can choose to be a public user or one of the official labels that would include Parody, Journalist, Politician, Government Employee, Corporate Brand, Corporate Officer, Corporate Employee, K-12 Teacher, College Professor, Police Officer, Governor, Mayor, United States Senator, United States Representative, State Senator (ST), State Representative (ST), Librarian, Firefighter, Lobbyist, Activist, Actor, Celebrity, Influencer, Artist, Poet, Author, Musician, and many more. Many of these would be paid accounts. Only Public User and verified public servent accounts are free (Journalist, K-12 Teacher, College Professor, Librarian, Police Office, etc)

#### Political Party and Nationality
Secondary labels of political party and nationality for some primary labels will be required

#### Handles and Title
Users would not be able to change their handle. Each user can add a title to their account, though any change will go through an automated moderation process to prevent mischief. Parody accounts will be allowed, but the image will be hard-wired to show the picture of a clown (a selection will be offerred) and the title will be prefixed with "Parody:". Titles would allow emojis and a wide Font selection.

### Free Capabilities

### Followers
Anyone can follow anyone as long as they meet the karma requirements of the account being followed. If you don't meet the requirements, you will be given an explanation, "This account requires a minimum Karma of 150 to be followed."

When followed, the user has the option of blocking the follower or "leveling" them from (1-99) with 1 being a trusted follower and 99 being allowed, but not to be trusted. The user can set a default level. Levels will never be shown publically to other people.

#### Posting, Replies, and Highlights
The concept of a "retweet" will be replaced by "Highlight" which will act in the same manner.

All users will be able to post on their own timeline. Each posts can have a custom karma filter or be limited to followers and then if limited to followers, can be further limited by follower level. Defaults for these will be available and can be changed for all future (but not past) posts.

Users can reply and/or highlight others posts (with exceptions). Users can prevent/allow replies and highlights to their timeline by karma level and/or follower level.

#### Edit
All accounts would be given 60 second edit capabilities on new posts. Significant changes to a post would not be allowed. Only simple grammar and spelling changes would be allowed.

#### Deleting
A user can delete any post at any time. Any replies or highlights will also be deleted, but a DM will be sent to the accounts that replied or highlighted that the original post has been deleted. There will be no broken branches in any timeline. Users have the right to control their timeline without exception.

#### Default algorithm would include:
- the most recent posts of your "circle", which you'll be able to define by tagging people from 1-10 when you follow them. Your inner circle will be everyone you tag with a 1.
- posts from 2-10 will follow by date time
- posts will have a read/unread flag so you won't see the same post twice unless you request it (there will be a filter button for "unread/read/all" that defaults to unread.
- ads: advertisers would be able to post an ad at the top of your timeline and the every 20 posts downward. Users cannot remove the top ad, but they can upgrade to remove further ads.
- no updates to timeline unless idol for 60 seconds or user clicks "update"

Every U.S. citizen that provides their location (privately) would automatically have a secondary Government timeline that shows who their local, state, and federal representitives are and the posts from those accounts.

### Creator Accounts
Some users may garner a larger following and can earn ad dollars. Once an account hits a certain threshhold (TBD), Phoenix Social will begin to split ad revenue with such accounts. These accounts can also can promote partner brands (that are approved) and recieve 95% of the ad revenue. So yes, Phoenix will pay its users where appropriate.

### Subscription Features
#### Verification
- Must prove identity and if applicable, your title (if you're a journalist, we're going to vet you)

#### Custom Timelines
Custom and alternate timeline buttons: user can define a search criteria and save it to labeled timeline button in the app, like "Favorite Teachers" or "My Inner Circle". The number of custom searches would be scaled by price within a montly subscription (the more custom timelines, the more you pay).

#### Ad Removal
Paid subscribers can remove all but top ad

#### Verifications
Verification is a paid feature unless the account holder is a verified public servant (including Journalist)

### Deleting Replies and Highlights
Paid users will have the ability to delete replies and highlights as they wish. The account that replied or highlighted will be notified by DM that this has happened. Again. Account holders will have explicit rights to maintain their timeline.

### Clients
#### Mobile
#### Web
#### API Access
- public unpaid: nothing can be created or added
- paid verified user: post on own behalf
- paid verified application: post on behalf of others (reminder, Phoenix Social will have a karma system. Any anti-societal behavior will be punished and those posts will see diminishing returns)
- posts will be heavily moderated and placed into a quarantine for peer review before being made public

### Global and Localization
#### Language
- English to start and prove the model

### Deployment Strategy
#### Cutting Edge Web Assembly
In the mid 2000's, Google published their Maps app built entirely on web technology. Up until that point, web based applications were delivered by server-rendered code with some minimal amount of JavaScript interactivity. Google used a mostly unknown capability to call microservices and interactively update the browser layout.

This changed the way everyone built web applications and was the beginning of single page applications and the invention of RESTful web services.

There are many directions future applications might be architectured, but it's our belief that Web Assembly will be the foundation of the next "Google Maps" type revolution.

So Phoenix Social is going to bypass all of the native mobile technology and app stores by developing a Web Assembly based application. There are many reasons, including avoiding the fees and oversight associated with deploying to the app stores, but also simplifying our browser codebase.

We'll need to push the envelope of what Web Assembly is capable of, but that's the direction we think browser based apps are going.