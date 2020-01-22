<template>
  <nav
    class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3"
  >
    <div class="container">
      <router-link to="/" class="navbar-brand" >Vue</router-link>
      <button
        class="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target=".navbar-collapse"
        aria-controls="navbarSupportedContent"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      <div
        class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse"
      >
        <ul class="navbar-nav flex-grow-1">
          <li class="nav-item">
            <router-link to="/" class="nav-link text-dark" >Home</router-link>
          </li>
          <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="#" data-toggle="dropdown">
              Order
            </a>
            <div class="dropdown-menu">
              <router-link to="/Order/List" class="dropdown-item">List</router-link>
              <router-link to="/Order/Create" class="dropdown-item">Create</router-link>
            </div>
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>

<script></script>
