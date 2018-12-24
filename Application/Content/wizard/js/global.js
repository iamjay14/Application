(function ($) {
    'use strict';
    /*[ Wizard Config ]
        ===========================================================*/
    
    try {
    
    
        $("#js-wizard-form").bootstrapWizard({
            'tabClass' : 'nav-tab',
            'nextSelector': '.btn-next',
            'previousSelector' : '.btn-back',
            'lastSelector': '.btn-last',
            'onNext': function(tab, navigation, index) {
                var progressBar = $('#js-progress').find('.progress-bar');
                var progressVal = $('#js-progress').find('.progress-val');
                var current = index + 1;
                console.log("Next"+index + " " + current);
                if (current > 1) {
                    var val = parseInt(progressBar.text());
                    val += 20;
                    progressBar.css('width', val+ '%');
                    progressVal.text(val+'%');
                }
    
            },
            'onPrevious': function (tab, navigation, index) {
                var progressBar = $('#js-progress').find('.progress-bar');
                var progressVal = $('#js-progress').find('.progress-val');
                var current = index;
                console.log("Previous" + index + " " + current);
                if (current >= 0) {
                    var val = parseInt(progressBar.text());
                    val -= 20;
                    progressBar.css('width', val+ '%');
                    progressVal.text(val+'%');
                }
    
            }
    
        });
    
    }
    catch (e) {
        console.log(e)
    }

})(jQuery);