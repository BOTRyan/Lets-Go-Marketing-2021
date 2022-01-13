mergeInto(LibraryManager.library, {
        newDiv: null,
        userSize: "",
        userAddress: "",
        userCity: "",
        userState: "",
        userZip: "",
        userUnit: "",
        userName: "",
        emailHref: "",
        AddElement__deps: ['newDiv', 'SetName', 'SetSize', 'SetAddress', 'SetUnit', 'SetCity', 'SetState', 'SetZip', 'RemoveElement'],
        SetMailto__deps: ['emailHref', 'userName', 'userSize', 'userAddress', 'userCity', 'userState', 'userUnit', 'userZip'],
        SetName__deps: ['SetMailto', 'userName'],
        SetSize__deps: ['SetMailto', 'userSize'],
        SetAddress__deps: ['SetMailto', 'userAddress'],
        SetUnit__deps: ['SetMailto', 'userUnit'],
        SetCity__deps: ['SetMailto', 'userCity'],
        SetState__deps: ['SetMailto', 'userState'],
        SetZip__deps: ['SetMailto', 'userZip'],
        RemoveElement__deps: ['newDiv','userName', 'userSize', 'userAddress', 'userCity', 'userState', 'userUnit', 'userZip'],

        Hello: function () {
            window.alert("Hello, World!");
        },
        AddElement: function () {
            _newDiv = document.createElement("div");
            _newDiv.setAttribute("id", "emailPopup");

            // Heading

            const heading = document.createElement("h1");
            const headText = document.createTextNode("Fill out the form below and we'll get the swag on its way!");
            heading.appendChild(headText);
            _newDiv.appendChild(heading);

            // Name Input
            const nameBox = document.createElement("input");
            nameBox.setAttribute("type", "text");
            nameBox.setAttribute("id", "name");
            nameBox.setAttribute("maxlength", 40);
            nameBox.addEventListener("change", _SetName);
            

            // Name Label
            const nameLabel = document.createElement("label");
            nameLabel.setAttribute("for", "name");
            nameLabel.setAttribute("id", "labelName");

            const nameLab = document.createTextNode("FIRST AND LAST NAME");
            nameLabel.appendChild(nameLab);
            
            _newDiv.appendChild(nameBox);
            _newDiv.appendChild(nameLabel);

            // Size Dropdown
            const sizeDropdown = document.createElement("select");
            sizeDropdown.setAttribute("id", "size");
            const option1 = document.createElement("option");
            const option1Name = document.createTextNode("S");
            option1.appendChild(option1Name);
            const option2 = document.createElement("option");
            const option2Name = document.createTextNode("M");
            option2.appendChild(option2Name);
            const option3 = document.createElement("option");
            const option3Name = document.createTextNode("L");
            option3.appendChild(option3Name);
            const option4 = document.createElement("option");
            const option4Name = document.createTextNode("XL");
            option4.appendChild(option4Name);
            const option5 = document.createElement("option");
            const option5Name = document.createTextNode("XXL");
            option5.appendChild(option5Name);

            sizeDropdown.appendChild(option1);
            sizeDropdown.appendChild(option2);
            sizeDropdown.appendChild(option3);
            sizeDropdown.appendChild(option4);
            sizeDropdown.appendChild(option5);
            sizeDropdown.addEventListener("change", _SetSize);
            

            // Size Label
            const sizeLabel = document.createElement("label");
            sizeLabel.setAttribute("for", "size");
            sizeLabel.setAttribute("id", "labelSize");

            const sizeLab = document.createTextNode("SIZE");
            sizeLabel.appendChild(sizeLab);
            
            _newDiv.appendChild(sizeDropdown);
            _newDiv.appendChild(sizeLabel);

            // Address Input

            const addressBox = document.createElement("input");
            addressBox.setAttribute("type", "text");
            addressBox.setAttribute("id", "address");
            addressBox.addEventListener("change", _SetAddress);
            

            // Address Label
            const addressLabel = document.createElement("label");
            addressLabel.setAttribute("for", "address");
            addressLabel.setAttribute("id", "labelAddress");

            const addressLab = document.createTextNode("ADDRESS");
            addressLabel.appendChild(addressLab);
            
            _newDiv.appendChild(addressBox);
            _newDiv.appendChild(addressLabel);

            // Unit Input
            const unitBox = document.createElement("input");
            unitBox.setAttribute("type", "text");
            unitBox.setAttribute("id", "unit");
            unitBox.addEventListener("change", _SetUnit);
            

            // Unit Label
            const unitLabel = document.createElement("label");
            unitLabel.setAttribute("for", "unit");
            unitLabel.setAttribute("id", "labelUnit");

            const unitLab = document.createTextNode("APT OR UNIT (OPTIONAL)");
            unitLabel.appendChild(unitLab);
           
            _newDiv.appendChild(unitBox);
            _newDiv.appendChild(unitLabel);

            // City Input
            const cityBox = document.createElement("input");
            cityBox.setAttribute("type", "text");
            cityBox.setAttribute("id", "city");
            cityBox.addEventListener("change", _SetCity);
            

            // City Label
            const cityLabel = document.createElement("label");
            cityLabel.setAttribute("for", "city");
            cityLabel.setAttribute("id", "labelCity");

            const cityLab = document.createTextNode("CITY");
            cityLabel.appendChild(cityLab);
            
            _newDiv.appendChild(cityBox);
            _newDiv.appendChild(cityLabel);

            // State Input
            const stateBox = document.createElement("input");
            stateBox.setAttribute("type", "text");
            stateBox.setAttribute("id", "state");
            stateBox.setAttribute("maxlength", 2);
            stateBox.setAttribute("minlength", 2);
            stateBox.addEventListener("change", _SetState);
            

            // State Label
            const stateLabel = document.createElement("label");
            stateLabel.setAttribute("for", "state");
            stateLabel.setAttribute("id", "labelState");

            const stateLab = document.createTextNode("STATE");
            stateLabel.appendChild(stateLab);
            
            _newDiv.appendChild(stateBox);
            _newDiv.appendChild(stateLabel);

            // Zip Input
            const zipBox = document.createElement("input");
            zipBox.setAttribute("type", "text");
            zipBox.setAttribute("id", "zip");
            zipBox.addEventListener("change", _SetZip);
            

            // Zip Label
            const zipLabel = document.createElement("label");
            zipLabel.setAttribute("for", "zip");
            zipLabel.setAttribute("id", "labelZip");

            const zipLab = document.createTextNode("ZIP CODE");
            zipLabel.appendChild(zipLab);
            
            _newDiv.appendChild(zipBox);
            _newDiv.appendChild(zipLabel);

            // Email Submit Button
            const emailTest = document.createElement("a");
            emailTest.setAttribute("id", "emailLink");

            const text = document.createTextNode("Submit");
            emailTest.appendChild(text);

            _newDiv.appendChild(emailTest);
            
            // Close Popup Button
            
            const closeButton = document.createElement("button");
            closeButton.setAttribute("type", "button");
            closeButton.setAttribute("id", "close");
            closeButton.addEventListener("click", _RemoveElement);

            const closeText = document.createTextNode("Nevermind");
            closeButton.appendChild(closeText);

            _newDiv.appendChild(closeButton);
            

            document.body.appendChild(_newDiv);

            
        },
        ThankYou: function () {
            window.alert("Thanks for your input!");
        },
        SetMailto: function () {
            if(_userName != "function _userName(){return _.apply(null,arguments)}" && _userSize != "function _userSize(){return _.apply(null,arguments)}" && _userAddress != "function _userAddress(){return _.apply(null,arguments)}" && _userCity != "function _userCity(){return _.apply(null,arguments)}" && _userState != "function _userState(){return _.apply(null,arguments)}" && _userZip != "function _userZip(){return _.apply(null,arguments)}") {
                if(_userUnit == "function _userUnit(){return _.apply(null,arguments)}") _userUnit = " ";
                _emailHref = "mailto:letsgomarketing@ferris.edu?subject=Interest%20Email&body=Hello! My name is " + _userName + ", and I'm interested in learning more about Ferris Marketing! My shirt size is " + _userSize + ", and you can mail it to this address: \r\n" + _userAddress + " " + _userUnit + "\r\n " + _userCity + ", " + _userState.toUpperCase() + ", " + _userZip;
                const link = document.getElementById("emailLink");
                link.setAttribute("href", _emailHref);
            }
          
        },
        SetName: function () {
            var nameInput = document.getElementById("name");
            _userName = nameInput.value;
            _SetMailto();
         
        },
        SetSize: function () {
            var sizeInput = document.getElementById("size");
            _userSize = sizeInput.options[sizeInput.selectedIndex].text;
            _SetMailto();
            
        },
        SetAddress: function () {
            var addressInput = document.getElementById("address");
            _userAddress = addressInput.value;
            _SetMailto();
            
        },
        SetUnit: function () {
            var unitInput = document.getElementById("unit");
            _userUnit = unitInput.value;
            _SetMailto();
            
        },
        SetCity: function () {
            var cityInput = document.getElementById("city");
            _userCity = cityInput.value;
            _SetMailto();
          
        },
        SetState: function () {
            var stateInput = document.getElementById("state");
            _userState = stateInput.value;
            _SetMailto();
            
        },
        SetZip: function() {
            var zipInput = document.getElementById("zip");
            _userZip = zipInput.value;
            _SetMailto();
            
        },
        RemoveElement: function () {
            
            _newDiv.remove();
            
            _userName = "";
            _userSize = "";
            _userAddress = "";
            _userUnit = "";
            _userCity = "";
            _userState = "";
            _userZip = "";
        }
});