<template>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container-fluid">
            <router-link class="link" to="/">
                <p class="navbar-brand fs-2">Forsvaret</p>
            </router-link>

        <div class=" navbar-collapse" id="navigationLinks">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <router-link class="link" to="/">
                        <p class="nav-link fs-4"> Hjem</p>
                    </router-link>
                </li>
                <li>
                    <router-link class="link" to="/soldier"> 
                        <p class="nav-link fs-4">Soldater</p> 
                    </router-link>
                </li>
                <li>
                    <router-link class="link" to="/weapon">
                        <p class="nav-link fs-4">Våpen</p>
                    </router-link>
                </li>
                <li>
                    <router-link class="link" to="/admin">
                        <p class="nav-link fs-4">Admin</p>
                    </router-link>
                </li>
            </ul>
        </div>
        </div>
    </nav>
    
</template>

<style scoped>


.link{
    text-decoration: none;
}
</style>