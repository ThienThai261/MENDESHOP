<script>
    // Lấy tất cả các phần tử quantity-control trên trang
    var quantityControls = document.querySelectorAll('.quantity-control');

    // Duyệt qua từng phần tử và thêm sự kiện cho nút tăng/giảm số lượng
    quantityControls.forEach(function(control) {
        var minusButton = control.querySelector('.minus-btn');
    var plusButton = control.querySelector('.plus-btn');
    var quantityInput = control.querySelector('.quantity-input');

    minusButton.addEventListener('click', function() {
            var currentValue = parseInt(quantityInput.value);
            if (currentValue > 1) {
        quantityInput.value = currentValue - 1;
            }
        });

    plusButton.addEventListener('click', function() {
            var currentValue = parseInt(quantityInput.value);
    quantityInput.value = currentValue + 1;
        });
    });
</script>