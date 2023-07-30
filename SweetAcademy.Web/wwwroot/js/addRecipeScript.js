let productList = [];
function addProducts(event) {

    let isConfirm = document.getElementById("flexSwitchCheckChecked").checked;

    if (!isConfirm) {
        window.alert("You should confirm with slider below the button");
        return;
    }

    const products = document.getElementsByClassName("productRow");
    for (const element of products) {
        if (element.getElementsByTagName("input")[1].checked) {
            if (element.getElementsByTagName("input")[0].value >= 1 && element.getElementsByTagName("input")[0].value % 1 == 0) {
                let Quantity = element.getElementsByTagName("input")[0].value;
                let Id = element.getElementsByTagName("input")[1].id;
                productList.push({ Id, Quantity });
            } else {
                window.alert("All checked in products must have an quantity value - integer(whole) number and must be greater than 0!")
                return;
            }
        }

    }
    if (productList.length >= 1) {
        document.querySelectorAll(".productRow input").forEach(element => {
            element.disabled = true;
        });
        document.querySelectorAll(".form-check-input").forEach(el => {

            if (el.checked == false) {
                el.parentElement.parentElement.remove()
            }
        })
        document.getElementById("productSubmit").textContent = "Submitted";
        document.getElementById("productSubmit").disabled = true;
        event.target.parentElement.getElementsByClassName("form-check form-switch d-inline-flex")[0].className = "d-none"
    } else {
        window.alert("Product list must contain at least one product! Please check if you filled in checkbox")
    }

};

var faqs_row = 0;
function addfaqs() {

    html = '<tr id="faqs-row' + faqs_row + '">';
    html += '<td><input type="text" placeholder="Recipe steps" class="form-control"></td>';
    html += '<td class="mt-10"><button type="button" class="btn btn-danger" onclick="$(\'#faqs-row' + faqs_row + '\').remove();"><i class="fa fa-trash"></i> Delete</button></td>';
    html += '</tr>';

    $('#faqs tbody').append(html);

    faqs_row++;
}

function addrecipe() {
    var token = $('input[name="__RequestVerificationToken"]').val();

    var body = {};
    body.__RequestVerificationToken = token;
    body.Name = document.getElementById('Name').value;
    body.Description = document.getElementById('Description').value;
    body.ImageUrl = document.getElementById('ImageUrl').value;
    body.Products = productList;

    if (!body.Name || !body.Description || !body.ImageUrl) {
        window.alert("Name, Description and Image link should not be emtpy fields!!!")
        return;
    };
    if (productList.length === 0) {
        window.alert("Please check if you submit product list for that recipe?")
        return;
    };
    var string = [];
    var array = document.getElementById('faqs').getElementsByTagName("input");
    for (const iterator of array) {
        if (!iterator.value) {
            window.alert("Step field shouldn`t be empty! You have to add at least one step for the recipe");
            return;
        } else if (iterator.value.length <= 10 && iterator.value >= 1000) {
            window.alert("Steps must be between 10 and 1000 characters long !")
            return;
        }

        string.push(iterator.value);
    }
    var StepsJSON = JSON.stringify(string);

    body.StepsJSON = StepsJSON;
    $.post("https://localhost:7217/Recipe/AddRecipe", body).done(function (data) { alert("Recipe added successfully!! ") });

    location.replace("https://localhost:7217/Recipe/AddRecipe");
}