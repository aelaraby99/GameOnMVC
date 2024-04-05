$('select').select2();

function previewImage(input) {
    var imgPreview = document.getElementById('cover-preview');
    var fileInput = input;

    if (fileInput.files && fileInput.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            imgPreview.src = e.target.result;
            imgPreview.removeAttribute('hidden');
        };
        reader.readAsDataURL(fileInput.files[0]);
    }
}

