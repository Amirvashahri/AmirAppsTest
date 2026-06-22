fetch('/Pages/header.html')
  .then(response => response.text())
  .then(data => {

    document.getElementById('header').innerHTML = data;

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

  });

fetch('/Pages/footer.html')
  .then(response => response.text())
  .then(data => {
    document.getElementById('footer').innerHTML = data;
  })
  .catch(error => console.error('Footer Error:', error));