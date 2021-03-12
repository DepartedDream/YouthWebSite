var clickTime = 0;
$(document).ready(function () {
    $($(".comment_content")[0]).text("樱花落下的速度的是每秒五厘米，");
    $($(".comment_content")[1]).text("我该用怎么样的速度，");
    $($(".comment_content")[2]).text("才能与你相遇。");
    $("#comment_belong").text("——秒速五厘米");
    $($(".comment_content")[0]).animate({ opacity: 1 }, 1000, function () {
        $($(".comment_content")[1]).animate({ opacity: 1 }, 1000, function () {
            $($(".comment_content")[2]).animate({ opacity: 1 }, 1000, function () {
                $("#comment_belong").animate({ opacity: 1 }, 1000);
            })
        })
    });
    $("#background").click(function () {
        clickTime = clickTime + 1;
        if (clickTime == 1) {
            $($(".comment_content")[0]).css("opacity", 0);
            $($(".comment_content")[1]).css("opacity", 0);
            $($(".comment_content")[2]).css("opacity", 0);
            $("#comment_belong").css("opacity", 0);
            $($(".comment_content")[0]).text("雨滴降落的速度是每秒十米，");
            $($(".comment_content")[1]).text("我该用怎么样的速度，");
            $($(".comment_content")[2]).text("才能将你挽留。");
            $("#comment_belong").text("——言叶之庭");
            $($(".comment_content")[0]).animate({ opacity: 1 }, 1000, function () {
                $($(".comment_content")[1]).animate({ opacity: 1 }, 1000, function () {
                    $($(".comment_content")[2]).animate({ opacity: 1 }, 1000, function () {
                        $("#comment_belong").animate({ opacity: 1 }, 1000);
                    })
                })
            });
        }
        else if (clickTime == 2) {
            $($(".comment_content")[0]).css("opacity", 0);
            $($(".comment_content")[1]).css("opacity", 0);
            $($(".comment_content")[2]).css("opacity", 0);
            $("#comment_belong").css("opacity", 0);
            $($(".comment_content")[0]).text("陨石坠落的速度是每秒十千米，");
            $($(".comment_content")[1]).text("我该用怎么样的速度，");
            $($(".comment_content")[2]).text("才能将你拯救。");
            $("#comment_belong").text("——你的名字");
            $($(".comment_content")[0]).animate({ opacity: 1 }, 1000, function () {
                $($(".comment_content")[1]).animate({ opacity: 1 }, 1000, function () {
                    $($(".comment_content")[2]).animate({ opacity: 1 }, 1000, function () {
                        $("#comment_belong").animate({ opacity: 1 }, 1000);
                    })
                })
            });
        }
        else {
            window.location.replace("Novel.aspx?novelId=1&chapterId=101");
        }
    })
})