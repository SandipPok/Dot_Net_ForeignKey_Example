// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function DeleteItem(btn) {
	var table = document.getElementById("ExpTable");

	if (table.rows.length <= 2) {
		var alert = document.querySelector(".alert");

		alert.textContent = "Cannot Remove Row";

		alert.classList.remove("d-none");

		setTimeout(() => {
			alert.classList.add("d-none");
        }, 2000);
	}
	else {
		$(btn).closest('tr').remove();
    }
}


function AddItem() {

	var table = document.getElementById('ExpTable');
	var rows = table.getElementsByTagName('tr');

	var rowOuterHtml = rows[rows.length - 1].outerHTML;

	var lastRowIdx = rows.length - 2;

	var nextRowIdx = Number(lastRowIdx) + 1;


	rowOuterHtml = rowOuterHtml.replaceAll('[' + lastRowIdx + ']', '[' + nextRowIdx + ']');

	console.log(rowOuterHtml);

	var newRow = table.insertRow();
	newRow.innerHTML = rowOuterHtml;
}