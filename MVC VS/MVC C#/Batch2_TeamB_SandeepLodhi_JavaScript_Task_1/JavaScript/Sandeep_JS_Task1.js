
function validateForm() {
    var FirstName = document.getElementById("FirstName").value;
    var LastName = document.getElementById("LastName").value;
    var DateOfBirth = document.getElementById("DateOfBirth").value;
    var Mobile = document.getElementById("Mobile").value;
    var Email = document.getElementById("Email").value;
    var Address = document.getElementById("Address").value;
    if (FirstName == "") {
        alert("First Name is required");
        return false;
    }

    if (LastName == "") {
        alert("Last Name is required");
        return false;
    }
    else if (DateOfBirth < 1) {
        alert("Date of birth is required");
        return false;
    }

    if (Mobile == "") {
        alert("Mobile No. is requried");
        return false;
    }

    else if (!Email.includes("@")) {
        alert("Invalid email address ");
        return false;
    }
    if (Address == "") {
        alert("Address is requried");
        return false;
    }
    return true;

}




// addrow()  function create for adding products
var data = 2;
function addrow() {
    const fields = document.createElement(`div`);
    fields.className = "row align-items-center justify-content-between mt-4 border-bottom mb-3";
    fields.innerHTML = ` 

    <div class="col mb-3">
    <label  class="form-label"></label>
    <input type="text" class="productName form-control" placeholder="sugar" id="ProductName">

</div>



<div class="col mb-3">
    <label class="form-label"></label>
    <input type="number" class="price form-control" placeholder="99₹" id="Price">

</div>



<div class="col mb-3">
    <label  class="form-label"></label>
    <input type="number" class="discount form-control" placeholder="12%"  id="Discount">

</div>



<div class="col mb-3"> 
    <label class="form-label"></label>
    <input type="number" class="inalPrice form-control" placeholder="9999₹" id="FinalPrice">

</div>



<div class="col mb-3">
    <label class="form-label"></label>
    <select class="productType form-select form-select-sm" id="ProductType">
        <option value="Vegitables">Vegitables</option>
        <option value="Cloths">Cloths</option>
        <option value="Electronics">Electronics</option>

    </select>
</div>



<div class="col mb-3">
    <label  class="form-label"></label>
    <select class="form-select form-select-sm" id="paymentStatus">
        <option value="Paid">Paid</option>
        <option value="UnPaid">UnPaid</option>

    </select>
</div>
<div class="col text-center">
    <button type="button" onclick="Del(this);" class="btn btn-danger px-3 mt-2">✖</button>
</div>
    
    `
    data++;
    const maindiv = document.getElementById("field");
    maindiv.appendChild(fields);

}

function Del(e) {                      // del() - function Ceate for Removing products fields.
    e.parentNode.parentNode.remove();

}

function Submit() {
    var FirstName = document.getElementById("FirstName").value;
    var LastName = document.getElementById("LastName").value;
    var DateOfBirth = document.getElementById("DateOfBirth").value;
    var Mobile = document.getElementById("Mobile").value;
    var Email = document.getElementById("Email").value;
    var Address = document.getElementById("Address").value;



    // let form = []
    // form.push("Name : "+FirstName + " "+LastName );
    // form.push("Date Of Birth : "+DateOfBirth);
    // form.push("Mobile No. :"+ Mobile);
    // form.push("Email : "+Email);
    // form.push("Address :" +Address);
    // console.log(form);

    var productName = document.getElementsByClassName("productName");
    var price = document.getElementsByClassName("price");
    var discount = document.getElementsByClassName("discount");
    var finalPrice = document.getElementsByClassName("finalPrice");
    var productType = document.getElementsByClassName("productType");
    var paymentStatus = document.getElementsByClassName("paymentStatus");


    //    let fieldsData={
    //     "ProductName":productName,
    //     "Price":price,
    //     "Discount":discount,
    //     "FinalPrice": finalPrice,
    //     "ProductType":productType,
    //     "PaymentStatus": paymentStatus
    //    }


    var array1 = [];
    let inputdata = {
        "FirstName": FirstName,
        "LastName": LastName,
        "DateOfBirth": DateOfBirth,
        "Mobile": Mobile,
        "Email": Email,
        "Address": Address,
    }
    array1.push(inputdata)

    for(var i=0;i<i.length;i++){
    let fieldsData = {
        "ProductName": productName[i].value,
        "Price": price[i].value,
        "Discount": discount[i].value,
        "FinalPrice": finalPrice[i].value,
        "ProductType": productType[i].value,
        "PaymentStatus": paymentStatus[i].value,
    }
    array1.push(fieldsData)
}
    console.log(array1);




}

