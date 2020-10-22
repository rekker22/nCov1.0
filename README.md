# nCov1.0

## Description

The Webapp tracks COVID Cases in India and displays them with heatmap(District wise). You can also search the name of the District or place to get Covid cases of a particular District.

## To Run Locally

### Prerequisite :
* Database Connection String
* Geocoding API Access Token from Mapbox- [Read the docs](https://docs.mapbox.com/api/search/)

### Steps to Follow
* Clone the repo and update acess token from Mapbox in `site.js` and update database connection string in `appsetting.json`.
* Do the migration to create the database locally 
* Run command 1 `add-migration CreatingDatabase` in Package Manager Console
* Run command 2 `update-database` in Package Manager Console
* Run the app and to populate the data in database Use Postman or any other tool to Create a POST request to `http://localhost:[PORT]/api/NCovStateDatas`

## Visual 


For live example - https://ncov1-0.herokuapp.com/


![Gif](https://1.bp.blogspot.com/-W2AM4IfaGuA/X5GroGzoFZI/AAAAAAAAIDw/duTw6pAgW8Q4kyEhZwBOQZmkMUl-_884QCLcBGAsYHQ/s1200-rw/ezgif.com-gif-maker.gif)


