tinyMCE.init({
    selector: "textarea",
    height: 480,
    plugins: 'autoresize autosave fullscreen image imagetools link media paste wordcount toc',
    toolbar: [
        'undo redo | styleselect | bold italic | link image',
        'alignleft aligncenter alignright',
        'restoredraft fullscreen image link media paste pastetext wordcount toc',
    ],
    menubar: 'view insert edit'
});
