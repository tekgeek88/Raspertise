
# Raspertise

## What is it

## Problem Statement:
The current advertising model allows advertisers to reach customers through large platforms ran by giant companies who decide when and which users to display advertisements to. These platforms are mostly online platforms which do not give advertisers the opportunity to display advertisements to the many americans that travel down the sidewalks and streets in front of small businesses. Another place where customers are able to see a lot of advertisements are in the back of ride-hailing companies like Uber and Lyft. According to the Seattle Times Uber and Lyft provide more than 91,000 rides per day. The current advertisement model does not allow these small business owners or Uber and Lyft drivers a chance to cash in on the 104.8 billion dollar per year advertising revenue (Fuller).

## Solution

Raspertise is a decentralized advertising platform allowing Raspberry Pi owners to display advertisements at their establishments while generating ad revenue. Advertisers will access the platform via a Web App and be able to select a raspberry pi’s location, generate a message to advertise, and then schedule their message to be displayed at their desired location or locations. This model takes a small platform fee much like Uber and Lyft while letting owners of the equipment and location to receive a large portion of the advertisement fees generated from advertisements broadcast from their location.

## Database Context

* Advertisers: Users who intend to pay for advertisment segments
* Locations: Possible locations for advertisers to choose for their advertisements to be displayed.
* Advertisements: A message that the advertiser intends to be broadcast at a location.

## The latest version

The current version of this program is written in .NET Core Version: 2.2.300
and using the Entity Framework V4.

## Installation

### 1. Download

* Clone or download the repository from github.

    * `git clone https://github.com/tekgeek88/Raspertise`

### 2. Prepare Visual Studio Solution

* Open with Visual Studio and build project.

  * Open **Raspertise.csproj** with Visual Studio.

  * click Build -> Build All from the toolbar

### 3. Prepare SQLite database

* Open your console and navigate to the path of your Raspertise project folder.
  * type `:~$ dotnet ef database update`

### 4. Run Web App from .NET CLI.

* To access the website on a Rasperry Pi from your local network start the web app using

  * `:~$ cd Dev/Dotnet/Raspertise`
  
  * `:~$ dotnet run --urls http://0.0.0.0:5001`

  * This allows you to access the webapp using your Raspbery Pi's IP address on your local network.

### 5. Run Python script to scroll advertisments.

* `:~$ cd Dev/DotNet/Raspertise-Pi/rpi-rgb-led-matrix/bindings/python/samples/`

* `:~$ sudo python runtext.py`

## Contact

If you have any comments or suggestions please feel free to leave them for us on GitHub
