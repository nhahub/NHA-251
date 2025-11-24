(function () {
    const pricePerPerson = parseFloat('@Model.PricePerOne'.replace(',', '.')) || 0;

    const input = document.querySelector('input[name="NumberOfPersons"]');
    const totalPriceSpan = document.getElementById('totalPrice');

    if (!input || !totalPriceSpan) return;

    function updateTotal() {
        const num = parseInt(input.value);

        if (!num || num <= 0) {
            totalPriceSpan.textContent = "";
            return;
        }

        const total = num * pricePerPerson;
        totalPriceSpan.textContent = total.toFixed(2);
    }

    input.addEventListener('input', updateTotal);
    updateTotal();
})();
