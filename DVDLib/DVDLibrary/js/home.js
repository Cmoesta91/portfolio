$(document).ready(function () {
    LoadDVD();
    $('#show-edit-dvd').hide();
    $('#searchDVD').hide();
    $('#viewDVD').hide();
});

function LoadDVD() {
    var contentRows = $('#DvdTable')
    var counter = 0;
    counter++;
    $.ajax({
        type: "GET",
        url: "http://localhost:52979/dvds",
        success: function (data, status) {
           $.each(data, function (index, item) {
               
               var row = '<tr>';
               row += '<td>' + counter + '</td>'
               row += '<td><a href="#foo" onclick="return singleDVD(' + item.dvdId + ');" style="color:black">' + item.title + '</a></td>';
               row += '<td>' + item.realeaseYear + '</td>';
               row += '<td>' + item.director + '</td>';
               row += '<td>' + item.rating + '</td>';
               row += '<td><button onclick="showEditForm(' + item.dvdId + ')">Edit</button></td>';
               row += '<td><button onclick="return confirm(\'Are you sure?\')? deleteDvd(' + item.dvdId + '):\'\';">Delete</button></td>';
               
               contentRows.append(row);
               counter++;
           })
        },
        error: function () {
            alert("FAILURE");
        }
    })
};

$('#search').click(function () {

    var counter1 = 0;
    counter1++;
    var categorgy = $('#categoryDD').val();
    var searchTerm =$('#searchTerm').val();
    var searchContentRows = $('#searchDVDTable')


    if (categorgy == 0){
      
        return false;
       
    }
    if (searchTerm == null){
       
        return false;
    }

    $('#displayDVD').hide();
    $('#searchDVD').show();
    
    $.ajax({
        type: "GET",
        url: "http://localhost:52979/dvds/" + categorgy + "/" + searchTerm,
        success: function (data, status) {
            $('#searchDVDTable').empty();
            $.each(data, function (index, item1) {
                var row1 = '<tr>';
                row1 += '<td>' + counter1 + '</td>'
                row1 += '<td>' + item1.title + '</td>';
                row1 += '<td>' + item1.realeaseYear + '</td>';
                row1 += '<td>' + item1.director + '</td>';
                row1 += '<td>' + item1.rating + '</td>';
                row1 += '<td><button onclick="showEditForm(' + item1.dvdId + ')">Edit</button></td>';
                row1 += '<td><button onclick="return confirm(\'Are you sure?\')? deleteDvd(' + item1.dvdId + '):\'\';">Delete</button></td>';
                
                searchContentRows.append(row1);
                counter1++;
            })
        },
        error: function () {
            alert("FAILURE");
            location.reload();
        }
    })

});

$("#CreateDVD").click(function () {
    $.ajax({
        type: "POST",
        url: "http://localhost:52979/dvd",
        data: JSON.stringify({
            title: $('#DvdTitle').val(),
            realeaseYear: $('#ReleaseYear').val(),
            director: $('#Director').val(),
            rating: $('#Rating').val(),
            notes: $('#Notes').val()
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
            success: function() {
               
                window.location = "home.html";
               
           },
           error: function() {
             alert("Didn't work")
           }
    })
});

function showEditForm(dvdId) {

    $('#displayDVD').hide();
    $('#searchDVD').hide();
    $('#show-edit-dvd').show();
    $('#nav').hide();

    $.ajax({
        type: 'GET',
        url: "http://localhost:52979/dvd/" + dvdId,
        success: function(data) {
              $('#edit-dvd-id').val(dvdId);
              $('#edit-title-input').val(data.title);
              $('#editTitle').text(data.title);
              $('#edit-realeaseYear-input').val(data.realeaseYear);
              $('#edit-director-input').val(data.director);
              $('#edit-rating-input').val(data.rating);
              $('#edit-note-input').val(data.notes);
          },
          error: function() {
              alert("GET REQUEST DIDNT WORK")
          }
    });
    
}

$('#edit-button').click(function (event) {
    $.ajax({
       type: 'PUT',
       url: 'http://localhost:52979/dvd/' + $('#edit-dvd-id').val(),
       data: JSON.stringify({
         dvdId: $('#edit-dvd-id').val(),
         title: $('#edit-title-input').val(),
         realeaseYear: $('#edit-realeaseYear-input').val(),
         director: $('#edit-director-input').val(),
         rating: $('#edit-rating-input').val(),
         notes: $('#edit-note-input').val()
       }),
       headers: {
         'Accept': 'application/json',
         'Content-Type': 'application/json'
       },
       'dataType': 'json',
        success: function() {

            $('#displayDVD').show();
            $('#show-edit-dvd').hide();
            $('#nav').show();
            location.reload();
          
       },
       error: function() {
          alert("IT DIDNT WORK CUZ YOUR DUMB");
       }
   })
});

function singleDVD(dvdId) {

    $('#viewDVD').show();
    $('#displayDVD').hide();
    $('#searchDVD').hide();
    $('#show-edit-dvd').hide();
    $('#nav').hide();

    $.ajax({
        type: 'GET',
        url: "http://localhost:52979/dvd/" + dvdId,
        success: function(data) {
              $('#viewDVDId').val(dvdId);
              $('#viewDVDTitle').text(data.title);
              $('#viewDVDRealeaseYear').val(data.realeaseYear);
              $('#viewDVDDirectort').val(data.director);
              $('#viewDVDRating').val(data.rating);
              $('#viewDVDNote').val(data.notes);
          },
          error: function() {
              alert("GET REQUEST DIDNT WORK")
          }
    });
    
}
    

function deleteDvd(dvdId) {

    $.ajax ({
        type: 'DELETE',
        url: "http://localhost:52979/dvd/" + dvdId,
        success: function (status) {
            $('#DvdTable').text("");
            LoadDVD();
        },
        error: function(){
          alert('Something didnt work');
        }
    });

}