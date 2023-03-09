$(function () {
	var $body = $('body');


	//----------  Close on click Outside of Container
	//------------------------------------------------------------------------------
	function clickOutsideContainer(selector, container, callback) {
		selector.on('mouseup', function (e) {
			e.stopPropagation();
			if (!container.is(e.target) && container.has(e.target).length === 0) {
				callback();
			}
		});
	};


	//----------  Modal
	//------------------------------------------------------------------------------
	function modal() {
		var modalInit = $('.js-modal-init');
		var modalInner = $('.js-modal-inner');
		var modalSel = $('.js-modal');
		var modalShowClass = 'is-visible';
		var buttonCreate = $('#btnCreate');

		modalInit.on('click', function () {
			modalSel.addClass(modalShowClass);
		});

		function closeModal() {
			modalSel.removeClass(modalShowClass);
		};


		buttonCreate.click(function () {
			closeModal();
		});

		clickOutsideContainer($body, modalInner, closeModal);
	}

	modal();
});



//----------  Date
//------------------------------------------------------------------------------
function todayDate() {
	var today = new Date();
	var dd = String(today.getDate()).padStart(2, '0');
	var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
	var yyyy = today.getFullYear();

	today = mm + '/' + dd + '/' + yyyy;

	const time = document.getElementById("todaysDate");
	time.innerHTML = today;
}


//----------  Random quotes
//------------------------------------------------------------------------------

function randomQuotes() {

	const quote = document.getElementById("header-quote");
	const author = document.getElementById("quote-author");

	let i = Math.floor(Math.random() * 6);

	quote.innerHTML = quotes[i];
	author.innerHTML = "- " + authors[i];


}

//----------  Fetch
//------------------------------------------------------------------------------
async function loadContent() {
	//fetch
	let response = await fetch('http://localhost:5249/controller', {
		method: 'GET',
	});
	//console.log(response);

	let result = await response.json();
	//console.log(result);

	const main = document.getElementById("main");
	const wrap = document.getElementById("wrap");
	//console.log(wrap, "WRAP");
	//console.log(main, "main")
	const response2 = main.removeChild(wrap);
	const wrap2 = document.createElement("div");
	wrap2.setAttribute('id', 'wrap');
	wrap2.classList.add('wrap');
	main.appendChild(wrap2)

	var selectValue = document.getElementById("userTasks");

	for (let i = 0; i < result.length; i++) {
		//console.log(i);
		const newItemRow = document.createElement("div");
		wrap2.appendChild(newItemRow);
		newItemRow.classList.add('item-row');


		//labels creating inside divs
		const label = document.createElement("label");
		newItemRow.appendChild(label);
		label.classList.add('check-flag');
		newItemRow.setAttribute("onclick", "update(" + result[i].id + ")");


		//spans creating inside labels
		const txtSpan = document.createElement("span");
		const btnSpan = document.createElement("span");
		const idSpan = document.createElement("span");
		const userSpan = document.createElement("span");

		label.appendChild(txtSpan);
		label.appendChild(btnSpan);
		newItemRow.appendChild(idSpan);
		newItemRow.appendChild(userSpan);

		txtSpan.classList.add('check-flag-label');
		btnSpan.classList.add('checkbox');
		idSpan.classList.add('labelNum');
		userSpan.classList.add('labelNum');
		txtSpan.textContent = result[i].title;
		idSpan.textContent = result[i].id;
		userSpan.textContent = result[i].user;


		//input creating
		const input = document.createElement("input");
		const checkmark = document.createElement("span");

		input.classList.add('checkbox-native');
		checkmark.classList.add('checkmark');

		btnSpan.appendChild(input);
		btnSpan.appendChild(checkmark);

		input.setAttribute("type", "checkbox");


		//elements creating iside checkmark span
		const svg = document.createElement("svg");
		svg.setAttribute("viewBox", "0 0 24 24");

		checkmark.appendChild(svg);
		btnSpan.setAttribute("type", "button");


		//path creating insidi svg
		const path = document.createElement("path");
		path.classList.add('checkmark-icon');

		svg.appendChild(path);

		path.setAttribute("fill", "none");
		path.setAttribute("stroke", "white");
		path.setAttribute("d", "M1.73,12.91 8.1,19.28 22.79,4.59");

		newItemRow.style.display = "none";

		if (selectValue.value.toString() == result[i].user) {
			newItemRow.style.display = "block";
		}
		else if (selectValue.value == "all") {
			newItemRow.style.display = "block";

		}


	}

}


//----------  POST
//------------------------------------------------------------------------------

async function create() {
	const txtTitle = document.getElementById("txtTitle");

	var selectValue = document.getElementById("users");
	//const btnCreate = document.getElementById("btnCreate");
	let jsObject = {
		title: txtTitle.value,
		id: 0,
		date: new Date(),
		user: selectValue.value.toString(),
		check: true
	}
	let request = await fetch('http://localhost:5249/controller', {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json'
		},
		body: JSON.stringify(jsObject),
	});
	loadContent();

	$('.btnCreate').click(function () {
		$('modal-wrap js-modal').modal('hide');
	});

}
//----------  PUT
//------------------------------------------------------------------------------
async function update(objId) {
	console.log("uspelo");

	let request = await fetch('http://localhost:5249/controller/UpdateToDoObject' + '?id=' + objId, {
		method: 'PUT',
		headers: {
			'Content-Type': 'application/json'
		},
	});
	setTimeout(loadContent, 1000)

	console.log(request)
	//let requestResult = await request.json();
	//console.log(requestResult);

}


//----------  DELETE
//------------------------------------------------------------------------------
/*async function Delete() {
	const btnCheck = document.querySelectorAll(".checkbox");

	if (btnCheck) {
		btnCheck.addEventListener("click", async function () {
			let request = await fetch('http://localhost:5249/controller', {
				method: 'DELETE',
				headers: { 'Content-Type': 'application/json' },
				body: JSON.stringify(jsObject),
			});
			console.log(request);
			let requestResult = await request.json();
			console.log(requestResult);
		})
	}
}*/

//----------  Filter Task
//------------------------------------------------------------------------------


//----------  Quotes and authors
//------------------------------------------------------------------------------
const authors = [
	"George Lorimer",
	"Thomas Carlyle",
	"Tricia Cunningham",
	"Karen E. Quinones Miller",
	"Karen Lamb",
	"Ingrid Bergman"
]
const quotes = [
	"You've got to get up every morning with determination if you're going to go to bed with satisfaction",
	"Go as far as you can see; when you get there, you'll be able to see further",
	"The individual who says it is not possible should move out of the way of those doing it",
	"When someone tells me no, it doesn't mean I can't do it, it simply means I can't do it with them",
	"A year from now you may wish you had started today",
	"Happiness is good health and a bad memory"
]