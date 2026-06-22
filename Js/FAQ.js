const details = document.querySelectorAll(".faq-container details");

details.forEach((detail) => {

    detail.addEventListener("toggle", () => {

        if (detail.open) {

            details.forEach((item) => {

                if (item !== detail) {
                    item.open = false;
                }

            });

        }

    });

});