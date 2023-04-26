// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function DeleteItem(btn) {
	$(btn).closest('tr').remove();
}

function AddItem() {

	var table = document.getElementById('ExpTable');
	var rows = table.getElementsByTagName('tr');

	var rowOuterHtml = rows[rows.length - 1].outerHTML;

	var newRow = table.insertRow();
	newRow.innerHTML = rowOuterHtml;
}