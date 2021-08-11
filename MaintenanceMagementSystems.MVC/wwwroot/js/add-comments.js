/*function AddComments() {

    var ticket = {
        ticketId: $('#updateId').val(),
        comment: $('#comments').val()

    }
    var commentStringfy = JSON.stringify(ticket);
    $.ajax({
        type: 'POST',
        url: '/BuildingManager/PostComments',      
        data: {
            ticketId: $('#updateId').val(),
            comment: $('#comments').val()},
        //contentType: 'application/json; charset=utf-8',
        success: function (data) {
            alert("Success");
        }
    });
}*/

$(document).ready(function () {
    //function will be called on button click having id btnsave
    $("#btnUpdate").click(function () {
        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "/BuildingManager/PostComments", // Controller/View
                data: { //Passing data
                    id: $('#updateId').val(),
                    comment: $('#comments').val()//Reading text box values using Jquery
                },
                success: function () {
                    location.reload(true);
                }

            });

    });
});