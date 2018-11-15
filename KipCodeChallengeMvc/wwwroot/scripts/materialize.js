$('.datepicker').pickadate({
    selectMonths: true, 
    selectYears: 100, 
    clear: 'Clear',
    close: 'Ok',
    closeOnSelect: false, 
    container: undefined,
    min: new Date('1/1/1938'),
    max: new Date('12/31/2000'),
    today: ''
});
