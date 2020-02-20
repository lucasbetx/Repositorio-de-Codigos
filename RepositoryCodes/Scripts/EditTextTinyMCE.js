tinymce.init({
    selector: "#Utilization",
    branding: false,
    plugins: 'codesample',
    codesample_languages: [
        { text: 'Code', value: 'markup' }
    ],
    menu: {
        file: { title: 'Documento', items: 'newdocument restoredraft | preview | print ' },
        edit: { title: 'Editar', items: 'undo redo | cut copy paste | selectall | searchreplace' },
        view: { title: 'Visualizar', items: 'code | visualaid visualchars visualblocks | spellchecker | preview fullscreen' },
        insert: { title: 'Inserir código', items: 'image link media template codesample inserttable | charmap emoticons hr | pagebreak nonbreaking anchor toc | insertdatetime' },
        format: { title: 'Formato', items: 'bold italic underline strikethrough superscript subscript codeformat | formats blockformats fontformats fontsizes align | forecolor backcolor | removeformat' },
        tools: { title: 'Tools', items: 'spellchecker spellcheckerlanguage | code wordcount' },
        table: { title: 'Table', items: 'inserttable | cell row column | tableprops deletetable' },
        help: { title: 'Help', items: 'help' }
    }
});