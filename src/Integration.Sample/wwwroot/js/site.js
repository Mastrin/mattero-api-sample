$(document).ready(function () {
	const resetInput = function (element) {
		if (element.nodeName === "INPUT") {
			element.value = null;
		}

		if (element.nodeName === "SELECT") {
			if (element.hasAttribute('data-search-select')) {
				$(element).val(null).trigger('change');
			} else {
				const options = element.options;
				for (var i = 0; i < options.length; i++) {
					options[i].selected = false;
				}
			}
		}
	}

	const setupCollapsableCheckboxes = function () {
		const removeHiddenAttribute = function (element) {
			if (element.hasAttribute('data-hidden')) {
				element.removeAttribute('data-hidden');
			}
		}

		const setHiddenAttribute = function (element) {
			if (!element.hasAttribute('data-hidden')) {
				element.setAttribute('data-hidden', '');
				element
					.querySelectorAll('input, select')
					.forEach(inputElement => resetInput(inputElement));
			}
		}

		const addHandlerForRadioButton = function (id, element) {
			element.addEventListener('click', event => {
				const target = event.target;

				document
					.querySelectorAll('*[data-checkbox-show="' + id + '"]') // get collapsable controls
					.forEach(collapsableElement => {
						const value = collapsableElement.getAttribute('data-checkbox-value');

						if (!!target.checked && target.hasAttribute('data-checkbox-true')) {
							if ((value + '').toLowerCase() === 'true') {
								removeHiddenAttribute(collapsableElement);
							} else {
								setHiddenAttribute(collapsableElement);
							}
						} else {
							if ((value + '').toLowerCase() === 'true') {
								setHiddenAttribute(collapsableElement);
							} else {
								removeHiddenAttribute(collapsableElement);
							}
						}
					});
			});
		}

		document
			.querySelectorAll('*[data-checkbox-show]') // Get controllers
			.forEach(element => {
				const id = element.getAttribute('data-checkbox-show'); // Radio buttons id
				document
					.querySelectorAll(id)
					.forEach(inputElement => addHandlerForRadioButton(id, inputElement));
			});
	};

	const setupSelect2Controls = function () {
		const isEmptyOrSpaces = function (str) {
			return str === null || str.match(/^ *$/) !== null;
		}

		const createBasicSelector = function (element) {
			$(element).select2();
		}

		const fillDataSourceSelectorDefault = function (element, parentId) {
			if (element.hasAttribute('data-search-select-default')) {
				const defaultValue = element.getAttribute('data-search-select-default');
				const source = element.getAttribute('data-search-select-source');

				let data = { id: defaultValue };
				if (!!parentId)
					data.parentId = parentId;

				if (!!defaultValue && !isEmptyOrSpaces(defaultValue) && !!source) {
					$.ajax({
						method: 'GET',
						url: source,
						dataType: 'json',
						data: data,
					}).then(function (data) {
						// create the option and append to Select2
						var option = new Option(data.text, data.id, true, true);
						$(element).append(option).trigger('change');

						// manually trigger the `select2:select` event
						$(element).trigger({
							type: 'select2:select',
							params: { data: data }
						});
					});
				}
			}
		}

		const createRootDataSourceSelector = function (element) {
			const source = element.getAttribute('data-search-select-source');

			$(element).select2({
				ajax: {
					method: 'GET',
					url: source,
					dataType: 'json',
					delay: 250,
					data: function (params) {
						return { term: params.term }
					},
					processResults: function (data) {
						return {
							results: data,
							pagination: { more: false }
						};
					},
					cache: true
				}
			});

			fillDataSourceSelectorDefault(element)
		}

		const createChildDataSourceSelector = function (element) {
			const parentId = element.getAttribute('data-search-select-parent');
			const parentElement = document.getElementById(parentId);

			const source = element.getAttribute('data-search-select-source');

			$(element).select2({
				ajax: {
					method: 'GET',
					url: source,
					dataType: 'json',
					delay: 250,
					data: function (params) {
						const optionId = $(parentElement).find('option:selected').val();
						return { parentId: optionId, term: params.term }
					},
					processResults: function (data) {
						return {
							results: data,
							pagination: { more: false }
						};
					},
					cache: true
				}
			});

			let oldOptionId = $(parentElement).find('option:selected').val();
			const toggleDisabled = function (optionId) {
				if (optionId === undefined) {
					optionId = $(parentElement).find('option:selected').val();
				}

				if (!!optionId && !isEmptyOrSpaces(optionId)) {
					let enable = false;

					if (element.hasAttribute('data-search-select-parent-filter')) {
						const parentFilter = element.getAttribute('data-search-select-parent-filter');
						if (!!parentFilter && !isEmptyOrSpaces(parentFilter)) {
							const filterOptions = parentFilter.split(',');
							filterOptions.forEach(filterOption => {
								if (filterOption.toLowerCase() == optionId.toLowerCase()) {
									enable = true;
								}
							});
						} else {
							enable = true;
						}
					}
					else {
						enable = true;
					}

					$(element).prop("disabled", !enable);
				} else {
					$(element).prop("disabled", true);
				}
			}


			if (parentElement.hasAttribute('data-search-select-source')) {
				let isFirst = true;

				$(parentElement).on('change', function () {
					const optionId = $(parentElement).find('option:selected').val();

					toggleDisabled(optionId);

					if (optionId != oldOptionId) {
						resetInput(element);
					}

					oldOptionId = optionId;

					if (isFirst) {
						fillDataSourceSelectorDefault(element, optionId)
						isFirst = false;
					}
				});
			} else {
				$(parentElement).on('change', function () {
					const optionId = $(parentElement).find('option:selected').val();

					toggleDisabled(optionId);

					if (optionId != oldOptionId) {
						resetInput(element);
					}

					oldOptionId = optionId;
				});

				fillDataSourceSelectorDefault(element)
			}

			toggleDisabled();
		}

		const createDataSourceSelector = function (element) {
			if (element.hasAttribute('data-search-select-parent')) {
				createChildDataSourceSelector(element);
			} else {
				createRootDataSourceSelector(element);
			}
		}

		const searchSelectors = document.querySelectorAll('*[data-search-select]');

		searchSelectors.forEach(element => {
			if (element.hasAttribute('data-search-select-source')) {
				createDataSourceSelector(element);
			} else {
				createBasicSelector(element);
			}
		});
	}

	const setupApiKeyModals = function () {
		var modals = document.querySelectorAll('[data-apikey-modal]')

		modals.forEach(modal => {
			$(modal).on('shown.bs.modal', function () {
				const url = modal.getAttribute('data-apikey-modal-entity-url');
				const entityType = modal.getAttribute('data-apikey-modal-entity-type');
				const linkType = modal.getAttribute('data-apikey-modal-link-type');

				$.ajax({
					headers: {
						'Accept': 'application/json',
						'Content-Type': 'application/json'
					},
					method: 'POST',
					url: '/api-links',
					dataType: 'json',
					data: JSON.stringify({
						url: url,
						entityType: entityType,
						linkType: linkType
					}),
				}).then(function (data) {
					const urlInput = modal.querySelector('[data-apikey-modal-url]');
					const passwordInput = modal.querySelector('[data-apikey-modal-password]');

					urlInput.value = data.url;
					passwordInput.value = data.password;
				});
			})
		})
	}

	setupCollapsableCheckboxes();
	setupSelect2Controls();
	setupApiKeyModals();
});