<?php include("inc/header.inc.php"); ?>

    <header>
        <div class="container-fluid backimg">
            <div class="jumbotron backimg">
                <div style="text-align: center;" class="backimg">
                    <a href="#" data-toggle="modal" data-target="#"><img src="img/employee.png" name="aboutme"
                                                                         width="140" height="140"
                                                                         class="img-circle"></a>
                    <div style="text-align: center" class="transparent">
                        <span class="badge">CEO / Founder</span>
                        <span style="color: white; "><p class="transparent">Valentin Valev</p></span>
                        <span style="color: white; "><p class="transparent">Studying Computing BSc at De Montfort University</p></span>
                        <span style="color: white; "><p class="transparent">Lives in Leicester</p></span>
                        <button class="btn btn-primary" type="button">
                            Follow <span class="badge"></span>
                        </button>
                        <button class="btn btn-primary" type="button">
                            Add Friend <span class="badge"></span>
                        </button>
                    </div>
                </div>
            </div>

            <div class="container">
                <ul class="nav nav-tabs navbar-border">
                    <li role="presentation"><a href="dashboard.php">Dashboard</a></li>
                    <li role="presentation" class="active"><a href="#">Profile</a></li>
                    <li role="presentation"><a href="messages.php">Messages</a></li>
                    <li role="presentation"><a href="gallery.php">Gallery</a></li>
                    <li role="presentation"><a href="videos.php">Video Gallery</a></li>
                    <li role="presentation"><a href="friends.php">Friends</a></li>
                    <li role="presentation"><a href="jobs.php">Jobs</a></li>
                </ul>
            </div>
    </header>

    <section class="section-01">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-12">
                    <h3 class="heading-large">Top posts</h3>
                    <textarea class="form-control" rows="3">Something in mind? Share it!</textarea>
                    <div class="buttonHolder">
                        <button type="button" class="btn btn-success">Post</button>
                    </div>
                    <br>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="card"><img class="img-fluid"
                                                   src="http://grafreez.com/wp-content/temp_demos/river/img/media-9.jpg"
                                                   alt="">
                                <div class="card-block">
                                    <div class="news-title"><a href="#">
                                            <h2 class=" title-small">Minorities Suffer From Unequal Pain Treatment</h2>
                                        </a></div>
                                    <p class="card-text">Some quick example text to build on the card title and make up
                                        the bulk of the card's content.</p>
                                    <p class="card-text">
                                        <small class="text-time"><em>3 mins ago</em></small>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="card"><img class="img-fluid"
                                                   src="http://grafreez.com/wp-content/temp_demos/river/img/media-10.jpg"
                                                   alt="">
                                <div class="card-block">
                                    <div class="news-title"><a href="#">
                                            <h2 class=" title-small">Minorities Suffer From Unequal Pain Treatment</h2>
                                        </a></div>
                                    <p class="card-text">Some quick example text to build on the card title and make up
                                        the bulk of the card's content.</p>
                                    <p class="card-text">
                                        <small class="text-time"><em>3 mins ago</em></small>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="card"><img class="img-fluid"
                                                   src="http://grafreez.com/wp-content/temp_demos/river/img/media-7.jpg"
                                                   alt="">
                                <div class="card-block">
                                    <div class="news-title"><a href="#">
                                            <h2 class=" title-small">Minorities Suffer From Unequal Pain Treatment</h2>
                                        </a></div>
                                    <p class="card-text">Some quick example text to build on the card title and make up
                                        the bulk of the card's content.</p>
                                    <p class="card-text">
                                        <small class="text-time"><em>3 mins ago</em></small>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="card"><img class="img-fluid"
                                                   src="http://grafreez.com/wp-content/temp_demos/river/img/media-8.jpg"
                                                   alt="">
                                <div class="card-block">
                                    <div class="news-title"><a href="#">
                                            <h2 class=" title-small">Minorities Suffer From Unequal Pain Treatment</h2>
                                        </a></div>
                                    <p class="card-text">Some quick example text to build on the card title and make up
                                        the bulk of the card's content.</p>
                                    <p class="card-text">
                                        <small class="text-time"><em>3 mins ago</em></small>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <aside class="col-lg-4 side-bar col-md-12">
                    <ul class="nav nav-tabs" role="tablist">
                        <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#home"
                                                role="tab">Latest</a></li>
                        <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#profile" role="tab">Top</a>
                        </li>
                        <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#messages"
                                                role="tab">Featured</a></li>
                    </ul>

                    <!-- Tab panes -->
                    <div class="tab-content sidebar-tabing">
                        <div class="tab-pane active" id="home" role="tabpanel">
                            <div class="media"><a class="media-left" href="#"> <img class="media-object"
                                                                                    src="http://grafreez.com/wp-content/temp_demos/river/img/media-1.jpg"
                                                                                    alt=""> </a>
                                <div class="media-body">
                                    <div class="news-title">
                                        <h2 class="title-small"><a href="#">Key Republicans sign letter warning against
                                                candidate</a></h2>
                                    </div>
                                    <div class="news-auther"><span class="time">1h ago</span></div>
                                </div>
                            </div>
                            <div class="media"><a class="media-left" href="#"> <img class="media-object"
                                                                                    src="http://grafreez.com/wp-content/temp_demos/river/img/media-2.jpg"
                                                                                    alt=""> </a>
                                <div class="media-body">
                                    <div class="news-title">
                                        <h2 class="title-small"><a href="#">Obamacare Appears to Be Making People
                                                Healthier</a></h2>
                                    </div>
                                    <div class="news-auther"><span class="time">1h ago</span></div>
                                </div>
                            </div>
                            <div class="media"><a class="media-left" href="#"> <img class="media-object"
                                                                                    src="http://grafreez.com/wp-content/temp_demos/river/img/media-3.jpg"
                                                                                    alt=""> </a>
                                <div class="media-body">
                                    <div class="news-title">
                                        <h2 class="title-small"><a href="#">Key Republicans sign letter warning against
                                                candidate</a></h2>
                                    </div>
                                    <div class="news-auther"><span class="time">1h ago</span></div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane" id="profile" role="tabpanel">
                            <div class="media"><a class="media-left" href="#"> <img class="media-object"
                                                                                    src="http://grafreez.com/wp-content/temp_demos/river/img/media-4.jpg"
                                                                                    alt=""> </a>
                                <div class="media-body">
                                    <div class="news-title">
                                        <h2 class="title-small"><a href="#">Key Republicans sign letter warning against
                                                candidate</a></h2>
                                    </div>
                                    <div class="news-auther"><span class="time">1h ago</span></div>
                                </div>
                            </div>
                            <div class="media"><a class="media-left" href="#"> <img class="media-object"
                                                                                    src="http://grafreez.com/wp-content/temp_demos/river/img/media-3.jpg"
                                                                                    alt=""> </a>
                                <div class="media-body">
                                    <div class="news-title">
                                        <h2 class="title-small"><a href="#">‘S.N.L.’ to Lose Two Longtime Cast
                                                Members</a></h2>
                                    </div>
                                    <div class="news-auther"><span class="time">1h ago</span></div>
                                </div>
                            </div>
                            <div class="media"><a class="media-left" href="#"> <img class="media-object"
                                                                                    src="http://grafreez.com/wp-content/temp_demos/river/img/media-2.jpg"
                                                                                    alt=""> </a>
                                <div class="media-body">
                                    <div class="news-title">
                                        <h2 class="title-small"><a href="#">Obamacare Appears to Be Making People
                                                Healthier</a></h2>
                                    </div>
                                    <div class="news-auther"><span class="time">1h ago</span></div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane" id="messages" role="tabpanel">
                            <div class="media"><a class="media-left" href="#"> <img class="media-object"
                                                                                    src="http://grafreez.com/wp-content/temp_demos/river/img/media-2.jpg"
                                                                                    alt=""> </a>
                                <div class="media-body">
                                    <div class="news-title">
                                        <h2 class="title-small"><a href="#">Key Republicans sign letter warning against
                                                candidate</a></h2>
                                    </div>
                                    <div class="news-auther"><span class="time">1h ago</span></div>
                                </div>
                            </div>
                            <div class="media"><a class="media-left" href="#"> <img class="media-object"
                                                                                    src="http://grafreez.com/wp-content/temp_demos/river/img/media-3.jpg"
                                                                                    alt=""> </a>
                                <div class="media-body">
                                    <div class="news-title">
                                        <h2 class="title-small"><a href="#">‘S.N.L.’ to Lose Two Longtime Cast
                                                Members</a></h2>
                                    </div>
                                    <div class="news-auther"><span class="time">1h ago</span></div>
                                </div>
                            </div>
                            <div class="media"><a class="media-left" href="#"> <img class="media-object"
                                                                                    src="http://grafreez.com/wp-content/temp_demos/river/img/media-1.jpg"
                                                                                    alt=""> </a>
                                <div class="media-body">
                                    <div class="news-title">
                                        <h2 class="title-small"><a href="#">Key Republicans sign letter warning against
                                                candidate</a></h2>
                                    </div>
                                    <div class="news-auther"><span class="time">1h ago</span></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="video-sec">
                        <h4 class="heading-small">Featured Video</h4>
                        <div class="video-block">
                            <div class="embed-responsive embed-responsive-4by3">
                                <iframe class="embed-responsive-item"
                                        src="https://www.youtube.com/embed/sYVKUlN1I9k?rel=0" allowfullscreen></iframe>
                            </div>
                        </div>
                    </div>
                </aside>
            </div>
        </div>
    </section>

<?php include("inc/footer.inc.php"); ?>