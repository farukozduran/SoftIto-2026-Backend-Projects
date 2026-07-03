$(document).ready(function () {
    if ($('#movieTableBody').length) {
        loadMovies();
    }
    if ($('#sessionTableBody').length) {
        loadSessions();
    }
    if ($('#announcementTableBody').length) {
        loadAnnouncements();
    }
});

function loadMovies() {
    $.ajax({
        url: '/Movies/MovieList',
        type: 'GET',
        success: function (data) {
            let rows = '';

            $.each(data, function (index, movie) {
                rows += `
                    <tr>
                        <td>
                            <div class="d-flex align-items-center gap-3">
                                <img src="${movie.imageUrl}" 
                                     style="width:60px; height:80px; object-fit:cover; border-radius:8px;" />
                                <strong>${movie.movieTitle}</strong>
                            </div>
                        </td>
                        <td>${movie.genre}</td>
                        <td>${movie.director}</td>
                        <td>${movie.duration} dk</td>
                        <td>${movie.description}</td>
                        <td class="text-end">
                            <button class="btn btn-sm btn-warning" onclick="editMovie(${movie.movieId})">Düzenle</button>
                            <button class="btn btn-sm btn-danger" onclick="deleteMovie(${movie.movieId})">Sil</button>
                        </td>
                    </tr>
                `;
            });

            $('#movieTableBody').html(rows);
        },
        error: function () {
            alert('Filmler listelenirken hata oluştu.');
        }
    });
}

function addMovie() {
    var movie = {
        MovieTitle: $('#movieTitle').val(),
        Genre: $('#genre').val(),
        Director: $('#director').val(),
        Duration: $('#duration').val(),
        Description: $('#description').val(),
        ImageUrl: $('#imageUrl').val()
    };

    $.ajax({
        url: '/Movies/AddMovie',
        type: 'POST',
        data: movie,
        success: function (response) {
            alert(response);

            clearMovieForm();

            $('#movieModal').modal('hide');

            loadMovies();
        },
        error: function () {
            alert('Film eklenirken hata oluştu.');
        }
    });
}
function deleteMovie(id) {
    var confirmDelete = confirm("Bu filmi silmek istediğinize emin misiniz?");

    if (!confirmDelete) {
        return;
    }

    $.ajax({
        url: '/Movies/DeleteMovie',
        type: 'POST',
        data: { id: id },
        success: function (response) {
            alert(response);
            loadMovies();
        },
        error: function () {
            alert('Film silinirken hata oluştu.');
        }
    });
}

function openAddMovieModal() {
    clearMovieForm();

    $('#movieModalLabel').text('Yeni Film Ekle');

    $('#btnAddMovie').show();
    $('#btnUpdateMovie').hide();
}

function editMovie(id) {
    $.ajax({
        url: '/Movies/EditMovie',
        type: 'GET',
        data: { id: id },
        success: function (movie) {
            if (movie == null) {
                alert('Film bulunamadı.');
                return;
            }

            $('#movieId').val(movie.movieId);
            $('#movieTitle').val(movie.movieTitle);
            $('#genre').val(movie.genre);
            $('#director').val(movie.director);
            $('#duration').val(movie.duration);
            $('#description').val(movie.description);
            $('#imageUrl').val(movie.imageUrl);

            $('#movieModalLabel').text('Film Düzenle');

            $('#btnAddMovie').hide();
            $('#btnUpdateMovie').show();

            $('#movieModal').modal('show');
        },
        error: function () {
            alert('Film bilgileri getirilirken hata oluştu.');
        }
    });
}

function updateMovie() {
    var movie = {
        MovieId: $('#movieId').val(),
        MovieTitle: $('#movieTitle').val(),
        Genre: $('#genre').val(),
        Director: $('#director').val(),
        Duration: parseInt($('#duration').val()),
        Description: $('#description').val(),
        ImageUrl: $('#imageUrl').val()
    };

    $.ajax({
        url: '/Movies/UpdateMovie',
        type: 'POST',
        data: movie,
        success: function (response) {
            alert(response);

            clearMovieForm();

            $('#movieModal').modal('hide');

            loadMovies();
        },
        error: function () {
            alert('Film güncellenirken hata oluştu.');
        }
    });
}

function clearMovieForm() {
    $('#movieId').val('');
    $('#movieTitle').val('');
    $('#genre').val('');
    $('#director').val('');
    $('#duration').val('');
    $('#description').val('');
    $('#imageUrl').val('');
}

// === SESSIONS AJAX LOGIC ===

function loadSessions() {
    $.ajax({
        url: '/Sessions/SessionList',
        type: 'GET',
        success: function (data) {
            let rows = '';
            $.each(data, function (index, session) {
                // Parse date for better display
                let dateObj = new Date(session.sessionDate);
                let formattedDate = dateObj.toLocaleDateString('tr-TR');

                rows += `
                    <tr>
                        <td><strong>${session.movieTitle}</strong></td>
                        <td><span class="badge bg-secondary">${session.hallName}</span></td>
                        <td>${formattedDate}</td>
                        <td>${session.sessionTime}</td>
                        <td>${session.ticketPrice} ₺</td>
                        <td><span class="badge ${session.emptySeatCount > 10 ? 'bg-success' : 'bg-danger'}">${session.emptySeatCount}</span></td>
                        <td class="text-end">
                            <button class="btn btn-sm btn-warning" onclick="editSession(${session.sessionId})">Düzenle</button>
                            <button class="btn btn-sm btn-danger" onclick="deleteSession(${session.sessionId})">Sil</button>
                        </td>
                    </tr>
                `;
            });
            $('#sessionTableBody').html(rows);
        },
        error: function () {
            alert('Seanslar listelenirken hata oluştu.');
        }
    });
}

function addSession() {
    var session = {
        MovieTitle: $('#sessionMovieTitle').val(),
        HallName: $('#hallName').val(),
        SessionDate: $('#sessionDate').val(),
        SessionTime: $('#sessionTime').val(),
        TicketPrice: parseFloat($('#ticketPrice').val()),
        EmptySeatCount: parseInt($('#emptySeatCount').val())
    };

    $.ajax({
        url: '/Sessions/AddSession',
        type: 'POST',
        data: session,
        success: function (response) {
            alert(response);
            clearSessionForm();
            $('#sessionModal').modal('hide');
            loadSessions();
        },
        error: function () {
            alert('Seans eklenirken hata oluştu.');
        }
    });
}

function deleteSession(id) {
    var confirmDelete = confirm("Bu seansı silmek istediğinize emin misiniz?");
    if (!confirmDelete) return;

    $.ajax({
        url: '/Sessions/DeleteSession',
        type: 'POST',
        data: { id: id },
        success: function (response) {
            alert(response);
            loadSessions();
        },
        error: function () {
            alert('Seans silinirken hata oluştu.');
        }
    });
}

function openAddSessionModal() {
    clearSessionForm();
    $('#sessionModalLabel').text('Yeni Seans Ekle');
    $('#btnAddSession').show();
    $('#btnUpdateSession').hide();
}

function editSession(id) {
    $.ajax({
        url: '/Sessions/EditSession',
        type: 'GET',
        data: { id: id },
        success: function (session) {
            if (session == null) {
                alert('Seans bulunamadı.');
                return;
            }

            $('#sessionId').val(session.sessionId);
            $('#sessionMovieTitle').val(session.movieTitle);
            $('#hallName').val(session.hallName);
            
            // Format date for input[type="date"]
            let dateObj = new Date(session.sessionDate);
            let year = dateObj.getFullYear();
            let month = ("0" + (dateObj.getMonth() + 1)).slice(-2);
            let day = ("0" + dateObj.getDate()).slice(-2);
            $('#sessionDate').val(`${year}-${month}-${day}`);
            
            $('#sessionTime').val(session.sessionTime);
            $('#ticketPrice').val(session.ticketPrice);
            $('#emptySeatCount').val(session.emptySeatCount);

            $('#sessionModalLabel').text('Seans Düzenle');
            $('#btnAddSession').hide();
            $('#btnUpdateSession').show();
            $('#sessionModal').modal('show');
        },
        error: function () {
            alert('Seans bilgileri getirilirken hata oluştu.');
        }
    });
}

function updateSession() {
    var session = {
        SessionId: $('#sessionId').val(),
        MovieTitle: $('#sessionMovieTitle').val(),
        HallName: $('#hallName').val(),
        SessionDate: $('#sessionDate').val(),
        SessionTime: $('#sessionTime').val(),
        TicketPrice: parseFloat($('#ticketPrice').val()),
        EmptySeatCount: parseInt($('#emptySeatCount').val())
    };

    $.ajax({
        url: '/Sessions/UpdateSession',
        type: 'POST',
        data: session,
        success: function (response) {
            alert(response);
            clearSessionForm();
            $('#sessionModal').modal('hide');
            loadSessions();
        },
        error: function () {
            alert('Seans güncellenirken hata oluştu.');
        }
    });
}

function clearSessionForm() {
    $('#sessionId').val('');
    $('#sessionMovieTitle').val('');
    $('#hallName').val('');
    $('#sessionDate').val('');
    $('#sessionTime').val('');
    $('#ticketPrice').val('');
    $('#emptySeatCount').val('');
}

// === ANNOUNCEMENTS AJAX LOGIC ===

function loadAnnouncements() {
    $.ajax({
        url: '/Announcements/AnnouncementList',
        type: 'GET',
        success: function (data) {
            let rows = '';
            $.each(data, function (index, announcement) {
                let dateObj = new Date(announcement.publishDate);
                let formattedDate = dateObj.toLocaleDateString('tr-TR');
                
                let statusBadge = announcement.isActive 
                    ? '<span class="badge bg-success">Aktif</span>' 
                    : '<span class="badge bg-secondary">Pasif</span>';

                rows += `
                    <tr>
                        <td>${statusBadge}</td>
                        <td><strong>${announcement.title}</strong></td>
                        <td class="text-truncate" style="max-width: 250px;" title="${announcement.content}">${announcement.content}</td>
                        <td>${formattedDate}</td>
                        <td class="text-end">
                            <button class="btn btn-sm btn-warning" onclick="editAnnouncement(${announcement.announcementId})">Düzenle</button>
                            <button class="btn btn-sm btn-danger" onclick="deleteAnnouncement(${announcement.announcementId})">Sil</button>
                        </td>
                    </tr>
                `;
            });
            $('#announcementTableBody').html(rows);
        },
        error: function () {
            alert('Duyurular listelenirken hata oluştu.');
        }
    });
}

function addAnnouncement() {
    var announcement = {
        Title: $('#title').val(),
        Content: $('#content').val(),
        PublishDate: $('#publishDate').val(),
        IsActive: $('#isActive').is(':checked')
    };

    $.ajax({
        url: '/Announcements/AddAnnouncement',
        type: 'POST',
        data: announcement,
        success: function (response) {
            alert(response);
            clearAnnouncementForm();
            $('#announcementModal').modal('hide');
            loadAnnouncements();
        },
        error: function () {
            alert('Duyuru eklenirken hata oluştu.');
        }
    });
}

function deleteAnnouncement(id) {
    var confirmDelete = confirm("Bu duyuruyu silmek istediğinize emin misiniz?");
    if (!confirmDelete) return;

    $.ajax({
        url: '/Announcements/DeleteAnnouncement',
        type: 'POST',
        data: { id: id },
        success: function (response) {
            alert(response);
            loadAnnouncements();
        },
        error: function () {
            alert('Duyuru silinirken hata oluştu.');
        }
    });
}

function openAddAnnouncementModal() {
    clearAnnouncementForm();
    $('#announcementModalLabel').text('Yeni Duyuru Ekle');
    
    // Set default date to today
    let today = new Date();
    let year = today.getFullYear();
    let month = ("0" + (today.getMonth() + 1)).slice(-2);
    let day = ("0" + today.getDate()).slice(-2);
    $('#publishDate').val(`${year}-${month}-${day}`);

    $('#btnAddAnnouncement').show();
    $('#btnUpdateAnnouncement').hide();
}

function editAnnouncement(id) {
    $.ajax({
        url: '/Announcements/EditAnnouncement',
        type: 'GET',
        data: { id: id },
        success: function (announcement) {
            if (announcement == null) {
                alert('Duyuru bulunamadı.');
                return;
            }

            $('#announcementId').val(announcement.announcementId);
            $('#title').val(announcement.title);
            $('#content').val(announcement.content);
            
            let dateObj = new Date(announcement.publishDate);
            let year = dateObj.getFullYear();
            let month = ("0" + (dateObj.getMonth() + 1)).slice(-2);
            let day = ("0" + dateObj.getDate()).slice(-2);
            $('#publishDate').val(`${year}-${month}-${day}`);
            
            $('#isActive').prop('checked', announcement.isActive);

            $('#announcementModalLabel').text('Duyuru Düzenle');
            $('#btnAddAnnouncement').hide();
            $('#btnUpdateAnnouncement').show();
            $('#announcementModal').modal('show');
        },
        error: function () {
            alert('Duyuru bilgileri getirilirken hata oluştu.');
        }
    });
}

function updateAnnouncement() {
    var announcement = {
        AnnouncementId: $('#announcementId').val(),
        Title: $('#title').val(),
        Content: $('#content').val(),
        PublishDate: $('#publishDate').val(),
        IsActive: $('#isActive').is(':checked')
    };

    $.ajax({
        url: '/Announcements/UpdateAnnouncement',
        type: 'POST',
        data: announcement,
        success: function (response) {
            alert(response);
            clearAnnouncementForm();
            $('#announcementModal').modal('hide');
            loadAnnouncements();
        },
        error: function () {
            alert('Duyuru güncellenirken hata oluştu.');
        }
    });
}

function clearAnnouncementForm() {
    $('#announcementId').val('');
    $('#title').val('');
    $('#content').val('');
    $('#publishDate').val('');
    $('#isActive').prop('checked', true);
}