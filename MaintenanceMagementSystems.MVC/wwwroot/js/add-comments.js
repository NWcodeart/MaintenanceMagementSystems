/*function AddComments() {

    var ticket = {
        ticketId: $('#updateId').val(),
        comment: $('#comments').val()

    }


    var commentStringfy = JSON.stringify(ticket);
    $.ajax({
        url: 'https://localhost:44386/BuildingManager/PostComments',
        type: 'POST',
        data: commentStringfy,
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            alert("Success");
        }
    });
}*/