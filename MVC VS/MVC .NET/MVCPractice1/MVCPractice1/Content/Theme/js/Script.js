
$(document).ready(function () {
    $('#users').DataTable();

    $('#Country_Id').on('change', function () {
        $.get("/Ajax/GetState", { id: $("#Country_Id").val() }, function (data) {
            $("#State_Id").empty();
            $.each(data, function (index, row) {
                $("#State_Id").append("<option value='" + row.id + "'>" + row.StateName + "</option>")
            })
        })
    });

    $('#State_Id').on('change', function () {
        $.get("/Ajax/GetCity", { id: $('#State_Id').val() }, function (data) {
            $('#City_Id').empty();
            $.each(data, function (index, row) {
                $("#City_Id").append("<option value='" + row.CityId + "'>" + row.CityName + "</option>")
            })
        })
    })
});