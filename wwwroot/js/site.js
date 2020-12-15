// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
    var coordinates = [22.944877, 81.075196];
    var heatmaponoff = true;
    var zoom = 4;
    var myArr = [];
    var mymap = L.map('mapid').setView(coordinates, zoom);
     L.tileLayer('https://{s}.tiles.mapbox.com/v4/openstreetmap.1b68f018/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoibGFuYXNvYzkxMCIsImEiOiJja2lwcDc2YTkxbXI4MnFsYmt6ZTdodnFvIn0.eV8T27Q44S7lipFGPtJzhg', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
     }).addTo(mymap);
    var heat = L.heatLayer(myArr, {radius: 25 }).addTo(mymap);
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
        //console.log(this.responseText);
        myArr = JSON.parse(this.responseText);
            heat = L.heatLayer(myArr, {radius: 25 }
            ).addTo(mymap);
        }
    };
    xhttp.open("GET", "api/ncsdget", true);
    xhttp.send();

    async function heatmaponoffchange() {
        if (heatmaponoff == false) {
        heatmaponoff = true;
            heat = L.heatLayer(myArr, {radius: 25 }
            ).addTo(mymap);
            document.getElementById("heatmapButton").src = "https://1.bp.blogspot.com/-_t_IxPhAtQU/X154biSv8uI/AAAAAAAAHwo/cJ7DGF7wXOgv9axNkpSyP860-ScG6o3GACLcBGAsYHQ/s685-rw/placewithoutheatmap.JPG";
        }
        else {
        heatmaponoff = false;
            mymap.removeLayer(heat);
            document.getElementById("heatmapButton").src = "https://1.bp.blogspot.com/-OejNjOgW-sA/X154bvCk9-I/AAAAAAAAHwk/7QyX2yClkpA2hmNDi83R6P-j3TipmWgOACLcBGAsYHQ/s686-rw/placewithheatmap.JPG";
        }
    }

    async function myFunction() {
        const response = await fetch('https://api.mapbox.com/geocoding/v5/mapbox.places/' + document.getElementById("searchEntry").value.split(" ").join('+') + "+India" + '.json?access_token=pk.eyJ1IjoicmVra2VyMjIiLCJhIjoiY2tjMXgzZTBmMWY5NDMwbjR2dzM0YjN3aiJ9.7l8XoNMK16WzYeYlE9mahQ');
        const data = await response.json();
        //console.log(data);
        coordinates = [data.features[0].center[1], data.features[0].center[0]];
        mymap.setView(coordinates, zoom);
        mymap.fitBounds([
            [data.features[0].bbox[1], data.features[0].bbox[0]],
            [data.features[0].bbox[3], data.features[0].bbox[2]]
        ]);
        for (var i in data.features[0].context) {
            if (data.features[0].context[i].id.split(".")[0] == "district")
            {
                var district = data.features[0].context[i].text;
                var xhttp = new XMLHttpRequest();
                xhttp.onreadystatechange = function () {
                    if (this.readyState == 4 && this.status == 200) {
                        //console.log(this.responseText);
                        var myarr = JSON.parse(this.responseText);
                        for (var d in myarr) {
                            if (myarr[d].dName == district) {
        document.getElementById("totalcases").innerHTML = district + " has total " + myarr[d].totalCases + " COVID cases.";
                                break;
                            }
                        }
                        document.getElementById("totalcases").value += "100";
                    }
                };
                xhttp.open("GET", "api/ncovstatedatas", true);
                xhttp.send();
                break;
            }
        }


    }