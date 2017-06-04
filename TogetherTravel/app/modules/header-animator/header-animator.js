require("./header-animator.css");

export default function HeaderAnimator(options) {
    const { maxAnimatedSheetOffsetPercentage, maxScrolledWindowOffsetPercentage, elem } = options;

    const visibleYSize = Math.max(
        document.documentElement.offsetHeight,
        document.body.offsetHeight,
        document.documentElement.clientHeight,
        document.body.clientHeight);

    const koff = maxAnimatedSheetOffsetPercentage / maxScrolledWindowOffsetPercentage;
    let completedAnimation = false;

    const drawAnimation = progress =>
        requestAnimationFrame(() => elem.style.transform = `translateY(${progress}%)`);

    const getTimeFraction = curOffset => {
        const timeFraction = curOffset / maxScrolledWindowOffsetPercentage;
        return timeFraction > 1 ? 1 : timeFraction;
    };

    const getProgress = timeFraction => -timeFraction * maxScrolledWindowOffsetPercentage * koff * 100;

    document.addEventListener("scroll",
        function(e) {
            const curScrolledWindowOffsetPercentage = window.pageYOffset / visibleYSize;
            const timeFraction = getTimeFraction(curScrolledWindowOffsetPercentage);
            const progress = getProgress(timeFraction);
            if (!completedAnimation)
                drawAnimation(progress);
            else if (progress === 1)
                completedAnimation = true;
        });
};