fetch('/Pages/header.html')
  .then(response => response.text())
  .then(data => {

    document.getElementById('header').innerHTML = data;

    // Active Page
    const currentPage = window.location.pathname
      .split("/")
      .pop();

    const links = document.querySelectorAll('.nav a');

    links.forEach(link => {

      const linkPage = link.getAttribute('href')
        .split("/")
        .pop();

      if (linkPage === currentPage) {
        link.classList.add('active');
      }

    });

    // =========================
    // Resources Dropdown
    // =========================

    const dropdown = document.querySelector(".nav-dropdown");
    const dropdownBtn = document.querySelector(".nav-dropdown-btn");

    if (dropdown && dropdownBtn) {

      dropdownBtn.addEventListener("click", function (e) {

        e.preventDefault();
        e.stopPropagation();

        dropdown.classList.toggle("active");

      });

      document.addEventListener("click", function () {

        dropdown.classList.remove("active");

      });

    }

  });

fetch('/Pages/footer.html')
  .then(response => response.text())
  .then(data => {

    document.getElementById('footer').innerHTML = data;

  })
  .catch(error => console.error('Footer Error:', error));